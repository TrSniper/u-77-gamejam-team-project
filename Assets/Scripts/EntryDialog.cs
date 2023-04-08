using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryDialog : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text dialogText;

    [SerializeField] string entryText;

    [SerializeField] int letterPerSecond;
    

    public static EntryDialog Instance {get; private set;}

    private bool isTyping, test = true;

    

    
    void Awake()
    {
        Instance = this;
        Instance.ShowDialog();
             
             
    }

    
    void Start()
    {
        AudioManager.Instance.PlaySFX("entry-screen");
        AudioManager.Instance.writingSource.PlayOneShot(AudioManager.Instance.writingSource.clip);   
    }

    public void ShowDialog(){       
        panel.SetActive(true);
        StartCoroutine(TypeDialog(entryText));       

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
        if(!isTyping && test){
            StartCoroutine(WaitForSecond());
            print("yazı bitti");
            test = false;
        }
    }

    public IEnumerator WaitForSecond(){
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }


}
