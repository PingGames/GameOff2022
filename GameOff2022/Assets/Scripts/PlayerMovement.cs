using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight= true;

    public Transform height;
    bool prev_grounded = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(isGrounded())
        {
        Debug.Log("Grounded!");
        }

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Debug.Log("Jump!");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            height.GetComponent<Animator>().SetTrigger("Stretch");
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 0.5f);
        }

        Flip();

        prev_grounded = isGrounded();

        if(isGrounded() && !prev_grounded)
        {
            height.GetComponent<Animator>().SetTrigger("Squash");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);    
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
