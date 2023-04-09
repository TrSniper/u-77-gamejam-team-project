using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        StartCoroutine(Resume());
    }

     private IEnumerator Resume(){   
        
        yield return new WaitForSecondsRealtime(1);
        
        Time.timeScale = 1;
        pauseMenu.SetActive(false);        
        isPaused = false;
        
         
        
    }

    public void GoToMainMenu(){        
        Time.timeScale = 1f;
        //SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
