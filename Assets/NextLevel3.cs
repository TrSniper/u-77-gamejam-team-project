using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel3 : MonoBehaviour
{
    public GameObject nextLevelGame;
    public Text text;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(Collectibles.iconCSharp == 7){
                AudioManager.Instance.PlaySFX("level-pass");
                StartCoroutine(WaitForSecondMethod("Kod yazmayı öğrendin."));
                             ;
            }else{
                nextLevelGame.SetActive(true);
                StartCoroutine(WaitForSecondMethod1("Hepsini toplamadan bir sonraki bölüme geçemezsin !!"));
                print("sonraki level");
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
