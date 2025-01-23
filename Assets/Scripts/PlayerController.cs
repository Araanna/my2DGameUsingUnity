using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    private bool isGrounded = true;
    private int jumpCount = 0;
    [SerializeField] private int maxJumps = 2;

    private bool isFacingRight = true;
    private Animator animator;
    float moveSpeeed = 200.0f;
    [SerializeField] GameObject fireball;
    [SerializeField] Transform firePoint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        if (Input.GetKeyDown(KeyCode.L))
        {
            //play gunshot audio

            //fire the fireball
            Instantiate(fireball, firePoint.position, firePoint.rotation);
        }
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Determine speed based on whether the LeftShift key is pressed
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);

        // Update animation states
        bool isMoving = moveInput != 0;
        animator.SetBool("isRun", Input.GetKey(KeyCode.LeftShift) && isMoving);
        animator.SetBool("isWalk", !Input.GetKey(KeyCode.LeftShift) && isMoving);

        // Flip sprite based on movement direction
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            isGrounded = false;
            animator.SetBool("isJump", true);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Invert the x-axis to flip the sprite
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
            animator.SetBool("isJump", false);
        }
    }



}
