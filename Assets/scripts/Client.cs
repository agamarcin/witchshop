using System;
using UnityEngine;
using UnityEngine.EventSystems;
using static Constants;
public class Client : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{
    
    [SerializeField] private string name;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool knowsMagic;
    
    //temporary
    [SerializeField]private Values neededValue;
    [SerializeField]private int neededStrenght;
    
    public delegate void LeaveShopDelegate();
    public static event LeaveShopDelegate OnLeave;

    private void randomizeAspectAndValue(){
        neededValue = (Values)UnityEngine.Random.Range(0, 7);
        neededStrenght = UnityEngine.Random.Range(1, 10);
    }
    
    private void Start()
    {
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

}
