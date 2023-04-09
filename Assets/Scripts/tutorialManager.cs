using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    
    private bool isPressed;
    public GameObject keyboardTutorialPanel;

    public void PressControlIcon(){
        if(!isPressed){
            keyboardTutorialPanel.SetActive(true);
            isPressed = true;
        }else{
            keyboardTutorialPanel.SetActive(false);
            isPressed = false;
        }
    }
}
