using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishSlider : MonoBehaviour
{
    public GameObject recScreenPanel, finishSliderText;
    public Text text;

    private bool oneShot;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!oneShot){
            if(Collectibles.iconYoutube == 7){
                if(other.gameObject.CompareTag("Player")){
            recScreenPanel.SetActive(false);
            SliderMovement.Instance.isMoving = false;
            StartCoroutine(showFinishText());
            oneShot = !oneShot;
            }
            }else{
                print("hata");
                StartCoroutine(showFinishText1());
            }
        }

        
    }

    IEnumerator showFinishText(){
        text.text = "Kayıt Tamamlandı...";
        finishSliderText.SetActive(true);        
        yield return new WaitForSeconds(1f);
        finishSliderText.SetActive(false);
    }

    IEnumerator showFinishText1(){
        text.text = "Tüm toplanabilirleri toplaman gerekiyor!";
        finishSliderText.SetActive(true);        
        yield return new WaitForSeconds(1f);
        finishSliderText.SetActive(false);
    }
}

