using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] float walkSpeed;
    float walkDirection;

    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] BoxCollider2D playerBox;

    [SerializeField] float dashSpeed;



    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    private bool IsGrounded()
    {
        RaycastHit2D isOnGround = Physics2D.BoxCast(playerBox.bounds.center, playerBox.bounds.size + new Vector3(0.1f, 0.1f, 0.1f), 0, Vector2.down, 0.01f, groundLayer);
        return isOnGround.collider != null;
    }

    private void MovePlayer()
    {
        walkDirection = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(walkSpeed * walkDirection, playerBody.velocity.y);
    }

    private void JumpPlayer()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
        }
    }
}
