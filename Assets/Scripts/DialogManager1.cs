using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager1 : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int letterPerSecond;

    private static int NPCCount = 0;

    public event Action OnShowDialog;
    public event Action OnHideDialog;

    Dialog dialog1;

    
    
    public static DialogManager1 Instance {get; private set;}

    
    private int currentLine = 0;

    private bool isTyping;
    
    void Awake()
    {
        Instance = this;        
        
    }

    
    

    public void HandleUpdate(){
        

        if(Input.GetKeyUp(KeyCode.Z) && !isTyping){
            ++currentLine;
            if(currentLine < dialog1.Lines.Count){
                AudioManager.Instance.writingSource.PlayOneShot(AudioManager.Instance.writingSource.clip);
                StartCoroutine(TypeDialog(dialog1.Lines[currentLine]));

            }else{
                dialogBox.SetActive(false);
                OnHideDialog?.Invoke();
                currentLine = 0;
                AudioManager.Instance.writingSource.Stop();
                
                              
                
            }

        }

    }

    public void ShowDialog(Dialog dialog){
        print("InShowDialog");
        OnShowDialog?.Invoke();
        this.dialog1 = dialog;       
        dialogBox.SetActive(true);        
        StartCoroutine(TypeDialog(dialog1.Lines[0]));
        AudioManager.Instance.writingSource.PlayOneShot(AudioManager.Instance.writingSource.clip);
        

    }
    

    public IEnumerator TypeDialog(string line){
        isTyping = true;
        dialogText.text = "";
        foreach(var letter in line.ToCharArray()){
            dialogText.text += letter;
            yield return new  WaitForSeconds(1f / letterPerSecond);
        }
        isTyping = false;
        AudioManager.Instance.writingSource.Stop();
    }

    
    void Update()
    {
        
    }
}
