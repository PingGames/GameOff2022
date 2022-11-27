using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUncover2_Up : MonoBehaviour
{
    [SerializeField]
    private GameObject _cover1;
    [SerializeField]
    private GameObject _cover2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _cover2.SetActive(false);
            _cover1.SetActive(true);
        }    
    }
}
