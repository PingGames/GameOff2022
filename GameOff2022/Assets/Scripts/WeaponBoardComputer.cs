using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoardComputer : MonoBehaviour
{
    public Transform bulletPos;

    public GameObject _bulletPrefab;
    private float _timer;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);
        // Debug.Log(distance);

        if (distance < 30)
        {
            _timer += Time.deltaTime;

            if (_timer > 2)
            {
                _timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(_bulletPrefab, bulletPos.position, Quaternion.identity);
    }
}
