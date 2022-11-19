using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform height;
    // TODO:"Change Starthealth of Player"
    public float playerHealth = 3f;

    private float _horizontal;
    private float _speed = 8f;
    private float _jumpingPower = 20f;
    private bool _prevGrounded = false;
    private bool _isFacingRight = true;
    
    


    [Header("Jumping and Physics")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    void Start()
    {

    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded())
        {
            Debug.Log("Grounded!");
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Debug.Log("Jump!");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
            height.GetComponent<Animator>().SetTrigger("Stretch");
        }

        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y + 0.5f);
        }

        Flip();

        _prevGrounded = isGrounded();

        if (isGrounded() && !_prevGrounded)
        {
            height.GetComponent<Animator>().SetTrigger("Squash");
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BulletBC"))
        {
            playerHealth = playerHealth - 1f;
            Debug.Log("Player Health -1! Now: " + playerHealth + "!");
        }
    }
}
