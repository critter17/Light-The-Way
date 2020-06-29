using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;
    private float moveSpeed = 5.0f;
    private float horizontal = 0.0f;

    private bool jump = false;
    public bool canMove = true;
    private float jumpVelocity = 13.0f;
    public bool isGrounded = true;
    public Transform feetTransform;
    private float circleRadius = 0.001f;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            if (isGrounded)
                jump = true;

        if(Input.GetButtonUp("Jump"))
            jump = false;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        //Rotate();
    }

    private void Rotate()
    {
        float camDistance = Camera.main.transform.position.y - transform.position.y;

        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));

        float angleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * angleRad;
        angle = Mathf.Clamp(angle, 0, 90);

        playerRigidBody.rotation = angle;
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetTransform.position, circleRadius, whatIsGround);

        if (jump && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpVelocity);
            jump = false;
        }
    }

    private void Move()
    {
        if (canMove)
        {
            horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));

            playerRigidBody.velocity = new Vector2(horizontal * moveSpeed, playerRigidBody.velocity.y);

            playerAnimator.SetFloat("Horizontal", horizontal);
            playerAnimator.SetFloat("LastMoveHorizontal", horizontal);
            

            if (horizontal == 0.0f)
            {
                playerAnimator.SetBool("IsMoving", false);
            }
            else
            {
                playerAnimator.SetBool("IsMoving", true);
            }
        }
        else
        {
            playerRigidBody.velocity = Vector2.zero;
        }   
    }
}
