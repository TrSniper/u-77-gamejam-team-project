using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStart1 : MonoBehaviour
{
    private bool oneShot;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && oneShot){
            anim_1.anim.gameObjects[0].SetActive(true);
            anim_1.anim.gameObjects[1].SetActive(true);
        }
    }
}
