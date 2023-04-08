using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    

    public static NPCController Instance;    

    private bool isTouch = false;

    public int index;
    

    

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite sprite;
    Sprite temp;

    

    
    void Awake()
    {
        Instance = this;
        
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        temp = spriteRenderer.sprite;
        
    }
    public void Interact(){
        

        DialogManager1.Instance.ShowDialog(dialog);
        
        
    }

    
    void Update()
    {
        if(!isTouch){
            spriteRenderer.sprite = temp;
        }
    }    
   
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.CompareTag("Player")){
        spriteRenderer.sprite = sprite;
        isTouch = true;
       }
   }

   
   void OnTriggerExit2D(Collider2D other)
   {
       if(other.gameObject.CompareTag("Player")){
        isTouch = false;
       }
   }

    
    
}
