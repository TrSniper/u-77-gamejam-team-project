using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFormManager : MonoBehaviour
{
    public GameObject startFormText;

    private bool oneShot;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !oneShot){
            startFormText.SetActive(true);
            oneShot = !oneShot;
        }
    }

    
}
