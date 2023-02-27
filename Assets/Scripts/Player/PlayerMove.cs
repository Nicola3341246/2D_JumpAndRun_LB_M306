using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] Animator playerAnimator;
    [SerializeField] float walkSpeed;
    float walkDirection;

    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] BoxCollider2D playerBox;
    bool isGrounded;

    [SerializeField] Transform playerTransform;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;
    Stopwatch dashTimer = new Stopwatch();
    bool canDash;

    private void Start()
    {
        dashTimer.Start();
    }

    void Update()
    {
        IsGrounded();
        MovePlayer();
        JumpPlayer();
        DashPlayer();
        LoadMenuScene();
    }

    private void IsGrounded()
    {
        RaycastHit2D isOnGround = Physics2D.BoxCast(playerBox.bounds.center, playerBox.bounds.size + new Vector3(0.1f, 0.1f, 0.1f), 0, Vector2.down, 0.01f, groundLayer);
        isGrounded = isOnGround.collider != null;
        if (isGrounded)
        {
            canDash = true;
        }
    }

    private void MovePlayer()
    {
        walkDirection = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Direction", walkDirection);
        if (dashTimer.ElapsedMilliseconds > dashTime)
        {
            playerBody.velocity = new Vector2(walkSpeed * walkDirection, playerBody.velocity.y);
        }
    }

    private void JumpPlayer()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
        }
    }

    private void DashPlayer()
    {
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded)
        {
            dashTimer.Restart();
            if (walkDirection < 0)
            {
                canDash = false;
                dashTimer.Restart();
                playerBody.velocity = new Vector2(dashSpeed * -1, playerBody.velocity.y);
            }
            else if (walkDirection > 0)
            {
                canDash = false;
                dashTimer.Restart();
                playerBody.velocity = new Vector2(dashSpeed, playerBody.velocity.y);
            }
        }
    }

    private void LoadMenuScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}