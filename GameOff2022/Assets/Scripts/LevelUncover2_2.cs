using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUncover2_2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _cover2;
    [SerializeField]
    private GameObject _cover3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(_cover3);
        }    
    }
}
