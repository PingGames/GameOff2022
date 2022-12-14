using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardComputer : MonoBehaviour
{
    public float healthScore;
    public GameObject bullet;
    public BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        healthScore = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScore == 0f)
        {
            bc.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            healthScore = healthScore - 1f;
            Debug.Log(healthScore);
        }
    }
}
