using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_1 : MonoBehaviour
{
    public GameObject[] gameObjects;

    public static anim_1 anim;

    void Awake()
    {
        anim = this;
    }
    
}
