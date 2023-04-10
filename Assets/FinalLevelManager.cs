using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalLevelManager : MonoBehaviour
{
    public GameObject panel;

    public Text text;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("final_level1")){
            text.text = "Video Çekerek macerana başlamıştın...";
            panel.SetActive(true);
            
        }

        if(other.gameObject.CompareTag("final_level2")){
            text.text = "Daha sonra Oryantasyon süreci geçirdin...";
            panel.SetActive(true);
            
        }

        if(other.gameObject.CompareTag("final_level3")){
            text.text = "C#'da kod yazmayı öğrendin ve öğrendiklerini Unity'de uyguladın...";
            panel.SetActive(true);
            
        }

        if(other.gameObject.CompareTag("final_level4")){
            text.text = "Güzel bir maceraydı, bol bol tecrübe kazandın...";
            panel.SetActive(true);
            
        }

        if(other.gameObject.CompareTag("clap-sound")){
            if(Collectibles.iconGraduate == 4){
                text.text = "Tebrikler mezun oldun...";
                AudioManager.Instance.PlaySFX("clap");
                panel.SetActive(true);
            }else{
                panel.SetActive(true);
                StartCoroutine(Wait("Gerekli Tüm Şeyleri Toplamadın!"));
            }
            
            
        }
    }

    IEnumerator Wait(string myText){
        text.text = myText;
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        panel.SetActive(false);
        
    }
}
