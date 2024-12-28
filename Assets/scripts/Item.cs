using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

using static Constants;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    
    // CHANGE INTO SCRIPTABLE OBJECTS
    
    
    [SerializeField] private Elements element;
    [FormerlySerializedAs("aspect")] [SerializeField] Values value;
    [SerializeField] private int strength;
    [SerializeField] private Transform transform;
    [SerializeField] private float defaultX, defaultY;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image image;
    
    [SerializeField] ItemSlot itemSlot;
    
    [SerializeField] private Sprite sprite;

    public void resetPosition(){
        transform.position = new Vector3(defaultX, defaultY, 0);
    }
    

    public void OnPointerDown(PointerEventData eventData){
    }
    
    public void OnBeginDrag(PointerEventData eventData){
        defaultX = eventData.position.x;
        defaultY = eventData.position.y;
        resetItemSlot();
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData){
    }

    public void setItemSlot(ItemSlot itemSlot){
        this.itemSlot = itemSlot;
    }

    public void resetItemSlot(){
        if (itemSlot != null){
            return;
        }

        itemSlot.setItem(null);
            setItemSlot(null);
        
    }

    public int getStrength(){
        return strength;
    }
    public Values getValue(){
        return value;
    }

    public Elements getElement(){
        return element;
    }

    public float getDefaultX(){
        return defaultX;
    }

    public float getDefaultY(){
        return defaultY;
    }

}
