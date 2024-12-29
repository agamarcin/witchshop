using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Constants;
public class Client : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{
    
    //add unlock condition
    
    //int relstionship=1
    //if(right spell)&&(reletionship%5!=0) relationship+=2 //-=2 if wrong spell?
    //if(reletionship%5==0)show additional dialogue option
    //if(did the dialogue && right spell) relationship+=2
    
    //spell preset as expected spell?
    //kept in a list, picked at random out of part of them
    //with higher relationship make bigger range of possible spells
    
    //multidelegate interaction?
    //dialogue class?
    //void diague()->order||exchange||shop||order||dialogue
    //void order()->give|| setup pickup date->dialogue->leave
    //void exchange()->dialogue->leave
    //void shop()->dialogue->leave
    //give dialogue to game controller, game conroller show it in dialogue box
    
    [SerializeField] private string name;
    [SerializeField] private string dialogue;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool knowsMagic;
    
    
    [SerializeField] private Image image;
    //temporary
    [SerializeField]private Values neededValue;
    [SerializeField]private int neededStrenght;
    
    public delegate void LeaveShopDelegate();
    public static event LeaveShopDelegate OnLeave;

    private void randomizeAspectAndValue(){
        neededValue = (Values)UnityEngine.Random.Range(0, 7);
        neededStrenght = UnityEngine.Random.Range(1, 10);
    }

    private void Awake(){

    }
    
    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprite;
        //temporary fction
        randomizeAspectAndValue();
    }

    private bool giveSpell(Spell spell){
        return spell.getValue((int)neededValue) >= neededStrenght;
    }

    private void leaveShop(){
        Debug.Log("client leaving shop");
        if (OnLeave != null){
            OnLeave();
        }
    }
    
    public void OnDrop(PointerEventData eventData){
        Debug.Log("dropped on client");
        if (eventData.pointerDrag == null){
            return;
        }
        Debug.Log("dropped something on client");

        if (eventData.pointerDrag.GetComponent<Spell>() == null){
            return;
        }

        Debug.Log("dropped spell on client");

                if (giveSpell(eventData.pointerDrag.GetComponent<Spell>())){
                    Debug.Log("right spell");
                    //destroy spell
                    //add positive to client story
                    //play dialogue
                    //client leave
                }else{
                    Debug.Log("wrong spell");
                    //IF KNOWS MAGIC
                    //client refuse, play dialogue
                    //choose to either do again or client leave(limited amount of time for that?)
                    
                    //IF DOESN'T KNOW MAGIC
                    //destroy spell
                    //add nagative to client story
                    //play dialogue
                    //client leave
                }
                //temporarily here, put this in the if later
                Destroy(eventData.pointerDrag.gameObject);
                leaveShop();
            }
            
    
    public void OnPointerEnter(PointerEventData eventData){
    }
    public void OnPointerExit(PointerEventData eventData){
    }

    public string getDialogue(){
        return dialogue;
    }

}
