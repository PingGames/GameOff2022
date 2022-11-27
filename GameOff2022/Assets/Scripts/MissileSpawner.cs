using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public Transform missilePos;

    private float _timer;

    [SerializeField]
    private GameObject _missile;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);
        // Debug.Log(distance);

        if (distance < 30)
        {
            _timer += Time.deltaTime;

            if (_timer > 5)
            {
                _timer = 0;
                Spawn();
            }
        }
    }

    void Spawn()
    {
        Instantiate(_missile, missilePos.position, Quaternion.identity);
    }
}
