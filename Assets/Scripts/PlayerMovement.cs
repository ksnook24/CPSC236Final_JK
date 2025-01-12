﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //general
    public CharacterController2D controller;
    public Animator animator;
    public bool hasFirstKey = false;
    public bool hasSecondKey = false;
    
    //general jump potion
    public bool hasJumpPotion = false;
    public int potionModAmount = 0;
   
    private float potionTimeMax = 10f;
    private float potionTimeCur = 0f;

    public float jumpVelocity = 1;


    //run
    public float runSpeed = 25f;
    float horizontalMove = 0f;


    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;

    private bool isGrounded;
    private int jumpCount = 0;

    //jump.1
    bool jumpFlag = false;
    bool jump = false;
    

    //health
    public static float healthAmount;
    public GameObject Panel;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        healthAmount = 0.5f;
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

        //Health
        if (healthAmount <= 0.1)
        {
            Debug.Log("You've Died!");
            if (Panel != null)                      // later replace this with restart button 
            {
                bool isActive = Panel.activeSelf;
                Panel.SetActive(!isActive);
            }

        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "BossBullet" || collision.gameObject.tag == "Spike")
        {
            healthAmount -= 0.1f;
        }

        if (collision.gameObject.tag == "Potion")
            jumpVelocity = 10;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }
}
