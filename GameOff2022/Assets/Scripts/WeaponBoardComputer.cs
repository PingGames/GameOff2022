using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoardComputer : MonoBehaviour
{
    public GameObject bulletBoardComputerPrefab;
    public Transform firePointBoardComputer;

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletBoardComputerPrefab, firePointBoardComputer.position, firePointBoardComputer.rotation);
    }
}
