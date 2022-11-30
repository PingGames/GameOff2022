using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Transform height;
    public int maxHealth = 5;
    public int currentHealth;
    public Healthbar healthBar;
    public GameObject fallDetector;

    private float _horizontal;
    private float _speed = 8f;
    private float _jumpingPower = 22.5f;
    private bool _prevGrounded = false;
    private bool _isFacingRight = true;
    private Vector3 _respawnPoint;

    [Header("Jumping and Physics")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _respawnPoint = transform.position;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
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

        if (currentHealth == 0f)
        {
            Debug.Log("Health equals 0");
            transform.position = _respawnPoint;
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
        if (other.CompareTag("BulletBC") || other.CompareTag("Missile"))
        {
            currentHealth = currentHealth - 1;
            healthBar.SetHealth(currentHealth);
        }

        if (other.CompareTag("Void"))
        {
            transform.position = _respawnPoint;
        }
    }

}
