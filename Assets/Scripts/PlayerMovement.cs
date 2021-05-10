using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //general
    public CharacterController2D controller;
    public Animator animator;
    public bool hasKey = false;

    //run
    public float runSpeed = 25f;
    float horizontalMove = 0f;

    // jump 
    [Range(1, 10)]
    public float jumpVelocity = 1;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;

    private bool isGrounded;
    private int jumpCount = 0;

    //jump.1
    bool jumpFlag = false;
    bool jump = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < 2))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
            jumpCount++;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
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

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }
}
