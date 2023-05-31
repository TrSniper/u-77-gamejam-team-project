using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collectibles.iconYoutube = 0;
        Collectibles.lives = 3;
        AudioManager.Instance.PlayMusic("theme2");
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Instance.musicSource.Stop();

    }
}
