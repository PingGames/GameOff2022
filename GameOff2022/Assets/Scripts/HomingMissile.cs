using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 200f;
    public GameObject explosionEffect;

    private Rigidbody2D _rb;
    private Transform _target;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)_target.position - _rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.up).z;
        _rb.angularVelocity = -rotateAmount * rotateSpeed;
        _rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
