using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUncover2_2_Up : MonoBehaviour
{
    [SerializeField]
    private GameObject _cover2;
    [SerializeField]
    private GameObject _cover3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _cover2.SetActive(false);
            _cover3.SetActive(true);
        }    
    }
}
