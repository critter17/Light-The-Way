using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
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
        horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));

        if(Input.GetButtonDown("Jump"))
            if (isGrounded)
                jump = true;

        if(Input.GetButtonUp("Jump"))
            jump = false;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetTransform.position, circleRadius, whatIsGround);

        if(canMove)
            playerRigidBody.velocity = new Vector2(horizontal * moveSpeed, playerRigidBody.velocity.y);
        else
            playerRigidBody.velocity = Vector2.zero;

        if(jump && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpVelocity);
            jump = false;
        }
    }
}
