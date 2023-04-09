using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText, escapeText;

    [SerializeField] int letterPerSecond;

    [SerializeField] Dialog dialog1;

    [SerializeField] GameObject selectMenu;

    [SerializeField] GameObject escapeState;

    

    [SerializeField] GameObject spaceKeyImage;
    
    public static DialogManager Instance {get; private set;}

    private int currentLine = 0;

    private bool isTyping;
    
    void Awake()
    {
        Instance = this;
        StartCoroutine(Instance.ShowDialog(dialog1));
        spaceKeyImage.SetActive(true);
        
    }

    public IEnumerator ShowDialog(Dialog dialog){
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
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
        if(Input.GetKeyDown(KeyCode.Space) && !isTyping){
            
            currentLine++;
            print("currentLine : " + currentLine);
            if(currentLine < dialog1.Lines.Count){
                AudioManager.Instance.writingSource.PlayOneShot(AudioManager.Instance.writingSource.clip);
                StartCoroutine(TypeDialog(dialog1.Lines[currentLine]));
            }else if(currentLine == 6){
                selectMenu.SetActive(true);
                spaceKeyImage.SetActive(false);
                AudioManager.Instance.writingSource.Stop();
                currentLine++;
            }            
            else{
                dialogBox.SetActive(false);
                currentLine = 0;
                AudioManager.Instance.writingSource.Stop();
                selectMenu.SetActive(false);
                
                
            }
            print("space");
            
        }

        if(currentLine == 7){
            if(Input.GetKeyDown(KeyCode.E)){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                }
                if(Input.GetKeyDown(KeyCode.Escape)){
                    dialogBox.SetActive(false);
                    currentLine = 0;
                    AudioManager.Instance.writingSource.Stop();
                    selectMenu.SetActive(false);
                    print("yakışmadı");
                    escapeState.SetActive(true);
                    StartCoroutine(escapeTheGame());


                }
        }
    }

    IEnumerator escapeTheGame(){
        escapeText.text = "Yakışmadı, Oyun Sonlanıyor...";
        yield return new WaitForSeconds(2f);
        
        Application.Quit();
    }
}
