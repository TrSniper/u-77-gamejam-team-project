using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishCodeLearn : MonoBehaviour
{
    public GameObject gameObject;
    public Text text;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            print("collider");
            gameObject.SetActive(true);
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait(){
        text.text = "Tebrikler, kodlamayı bitirdin!";
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
