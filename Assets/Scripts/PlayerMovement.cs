using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public bool hasKey = false;
    public float jumpVelocity = 2;

    public float runSpeed = 25f;

    float horizontalMove = 0f;
    bool jumpFlag = false; // are we jumping, already jumped
    bool jump = false;

    private bool isGrounded = true;
    private int jumpCount = 0;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (jumpFlag)
        {
            animator.SetBool("IsJumping", true);
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < 2))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
            jumpCount++;
        }
    }

    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}
