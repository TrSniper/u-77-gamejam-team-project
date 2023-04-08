using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{FreeRoam, Dialog}

public class GameManager : MonoBehaviour
{
    [SerializeField] characterController characterController;

    GameState state;

    
    void Start()
    {
        DialogManager1.Instance.OnShowDialog += () => {
            state = GameState.Dialog;
        };
        DialogManager1.Instance.OnHideDialog += () => {
            state = GameState.FreeRoam;
        };
    }

    
    void Update()
    {
        if(state == GameState.FreeRoam){
            characterController.HandleUpdate();
        }else if(state == GameState.Dialog){
            DialogManager1.Instance.HandleUpdate();

        }
    }
}
