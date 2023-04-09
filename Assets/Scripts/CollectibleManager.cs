using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{

    public Text youtubeCountText;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("icon_youtube")){
            Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX("collectible");
            Collectibles.iconYoutube++;
            youtubeCountText.text = Collectibles.iconYoutube.ToString();
            print("icon_youtube : " + Collectibles.iconYoutube);
        }

        if(other.gameObject.CompareTag("icon_form")){
            Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX("collectible");
            Collectibles.iconForm++;
            youtubeCountText.text = Collectibles.iconForm.ToString();
            print("icon_form : " + Collectibles.iconForm);
        }
    }
}
