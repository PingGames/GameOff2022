using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUncover3_Up : MonoBehaviour
{
    [SerializeField]
    private GameObject _cover2;
    [SerializeField]
    private GameObject _cover3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Meh!");
            _cover3.SetActive(false);
            _cover2.SetActive(true);
        }    
    }
}
