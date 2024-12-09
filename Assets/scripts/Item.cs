using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    
    // CHANGE INTO SCRIPTABLE OBJECTS
    
    
    [SerializeField] Constants.Elements element;
    [SerializeField] Constants.Aspects aspect;
    [SerializeField] Transform transform;
    [SerializeField] int defaultX, defaultY;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Image image;
    
    [SerializeField] ItemSlot itemSlot;
    
    [SerializeField] private Sprite sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition(){
        transform.position = new Vector3(defaultX, defaultY, 0);
    }
    

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("BeginDrag");
        resetItemSlot();
        //image.raycastTarget = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        Debug.Log("Drag");
        transform.position = eventData.position;
        //transform.anchoredPosition+= eventData.delta;//divide by canvas scaleFactor if movement problems
    }
    public void OnEndDrag(PointerEventData eventData){
        
        //if(eventData.pointerDrag != null){
            //check if it actually dropped in item slot
            //eventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            //setItemSlot(eventData.pointerDrag.GetComponent<ItemSlot>());
            Debug.Log("EndDrag");

            //itemSlot=eventData.pointerDrag.GetComponent<ItemSlot>();
            //itemSlot.setItem(this);
        //}else{
            //itemSlot.setItem(null);
            //itemSlot=null;
        //}
        //image.raycastTarget = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
    }

    public void setItemSlot(ItemSlot itemSlot){
        this.itemSlot = itemSlot;
    }

    public void resetItemSlot(){
        if (itemSlot != null)
        {
            itemSlot.setItem(null);
            setItemSlot(null);
        }
    }

    public Constants.Aspects getAspect(){
        return aspect;
    }

    public Constants.Elements getElement(){
        return element;
    }

    public int getDefaultX(){
        return defaultX;
    }

    public int getDefaultY(){
        return defaultY;
    }

}
