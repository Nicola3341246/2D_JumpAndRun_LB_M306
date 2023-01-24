using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] float walkSpeed;
    float walkDirection;



    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MovePlayer()
    {
        walkDirection = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(walkSpeed * walkDirection * Time.deltaTime, 0);
    }

    private void JumpPlayer()
    {

    }
}
