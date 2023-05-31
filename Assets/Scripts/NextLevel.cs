using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject nextLevelGame;

    

    public Text text;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(Collectibles.iconYoutube == 7){
            AudioManager.Instance.PlaySFX("level-pass");
            StartCoroutine(WaitForSecondMethod("Tebrikler Videoyu Çektin, Sisteme yükleniyor..."));                    
                        
        }else{
            StartCoroutine(WaitForSecondMethod1("Hepsini toplamadan bir sonraki bölüme geçemezsin !!"));          

        }

        

        }
        

        



        
    }

    IEnumerator WaitForSecondMethod(string myText){
        text.text = myText;
        nextLevelGame.SetActive(true);
        yield return new WaitForSeconds(2f);
        nextLevelGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
        
        
    }

    IEnumerator WaitForSecondMethod1(string myText){
        text.text = myText;
        nextLevelGame.SetActive(true);
        yield return new WaitForSeconds(2f);
        nextLevelGame.SetActive(false);
        
        
        
    }

    
}
