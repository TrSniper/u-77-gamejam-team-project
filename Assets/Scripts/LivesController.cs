using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    
    void Awake()
    {
        switch(Collectibles.lives){
            case 3:                
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 0:
                print("canın bitti");
                Collectibles.lives = 3;
                Collectibles.iconCSharp = 0;
                Collectibles.iconForm = 0;
                Collectibles.iconGraduate = 0;
                Collectibles.iconYoutube = 0;
                print("can yenilendi");
                break;
            default:
                break;
        }
    }
}
