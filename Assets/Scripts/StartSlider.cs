using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSlider : MonoBehaviour
{

    private bool oneShot;

    public GameObject recScreenPanel, startRecordingText;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!oneShot){
            if(other.gameObject.CompareTag("Player")){
            SliderMovement.Instance.isMoving = true;
            recScreenPanel.SetActive(true);
            StartCoroutine(showRecordingText());
            oneShot = !oneShot;
        }


        }
        
    }

    IEnumerator showRecordingText(){
        startRecordingText.SetActive(true);
        print("kayıt başladı");
        yield return new WaitForSeconds(1.5f);
        startRecordingText.SetActive(false);
    }
}
