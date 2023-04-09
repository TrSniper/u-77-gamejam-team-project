using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;

    private SpriteRenderer spriteRenderer;

    private bool one = true;

    private int moveDirection = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        transform.Translate(new Vector3(speed * moveDirection * Time.deltaTime, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("wall1")){
            
            moveDirection *= -1;
            spriteRenderer.flipX = false;
            
        }

        if(other.gameObject.CompareTag("wall2")){
            
            moveDirection *= -1;
            spriteRenderer.flipX = true;
        }

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && one){
            one = false;
            Collectibles.lives--;
            Collectibles.iconYoutube = 0;            
            AudioManager.Instance.PlaySFX("character-dead");            
            StartCoroutine(WaitForSecondMethod());
            
        }
    }

    IEnumerator WaitForSecondMethod(){
        yield return new WaitForSeconds(1f);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
