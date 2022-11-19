using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardComputerBullet : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = _player.transform.position - transform.position;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if (hitInfo.CompareTag("Player"))
        {
            Destroy(gameObject);
            //TODO: Make special Player-HitSound and implement
        }

        if(!hitInfo.CompareTag("BC"))
        {
            Destroy(gameObject);
        }
        
    }
}
