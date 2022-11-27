using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUncover2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _cover1;
    [SerializeField]
    private GameObject _cover2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("");
        }    
    }
}
