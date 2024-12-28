using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using static Constants;
public class Client : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{
    [SerializeField] String name;
    
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool knowsMagic;
    
    [FormerlySerializedAs("neededAspect")] [SerializeField]Values neededValue;
    [SerializeField]private int neededStrenght;
    
    public delegate void LeaveShopDelegate();
    public static event LeaveShopDelegate OnLeave;

    void randomizeAspectAndValue(){
        neededValue = (Constants.Values)UnityEngine.Random.Range(0, 7);
        neededStrenght = UnityEngine.Random.Range(1, 10);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        randomizeAspectAndValue();
    }

    public bool giveSpell(Spell spell){

        if (spell.getValue((int)neededValue) >= neededStrenght){
            return true;
        }
        return false;
    }

    public void leaveShop(){
        Debug.Log("client leaving shop");
        if(OnLeave != null)OnLeave();

    }
    
    public void OnDrop(PointerEventData eventData){
        Debug.Log("dropped on client");
        if (eventData.pointerDrag != null) {
            
            Debug.Log("dropped something on client");
            if (eventData.pointerDrag.GetComponent<Spell>() !=null){
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
            //eventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            //setItem(eventData.pointerDrag.GetComponent<Item>());
            //item.setItemSlot(this);
            }
        //Debug.Log("Item dropped to slot");
        //Debug.Log("dropped to slot "+gameObject.name);
        //if (eventData.pointerDrag != null) {
            //eventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            //setItem(eventData.pointerDrag.GetComponent<Item>());
            //item.setItemSlot(this);
        //}
    }
    public void OnPointerEnter(PointerEventData eventData){
        // canvasGroup.alpha = 0.5f;
        // Debug.Log("Item entered slot");
    }
    public void OnPointerExit(PointerEventData eventData){
        // canvasGroup.alpha = 1;
        //Debug.Log("Item entered slot");
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
