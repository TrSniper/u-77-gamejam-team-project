using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishUnity : MonoBehaviour
{
    public GameObject startFormText;
    public Text finishText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            print(Collectibles.iconCSharp);
            if(Collectibles.iconCSharp == 7){
                startFormText.SetActive(true);
                StartCoroutine(WaitForForm());
            }else{
                startFormText.SetActive(true);
                StartCoroutine(WaitForForm1());
            }
        }
    }

    IEnumerator WaitForForm(){
        finishText.text = "Tebrikler, hepsini topladın!";
        yield return new WaitForSeconds(2f);
        startFormText.SetActive(false);

    }

    IEnumerator WaitForForm1(){
        finishText.text = "Hepsini almadın!!!";
        yield return new WaitForSeconds(2f);
        startFormText.SetActive(false);

    }
}
