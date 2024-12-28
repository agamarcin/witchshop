using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using static Constants;


public class Spell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private Elements element;
    [SerializeField] private int strength;
    [SerializeField] private int stability;
    [SerializeField] private List<int> values;
    [SerializeField] private CanvasGroup canvasGroup;
    
    [SerializeField] private Sprite sprite;

    public Spell(Item item){
        Debug.Log("spell called");
    }

    public Values calcAspect(){

        return Values.NUA;

    }

    public void OnDrop(PointerEventData eventData){
    }
    
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
    }
    

    public void setValue(int index, int value){
        values[index] = value;
    }

    public void setElement(Elements element){
        this.element = element;
    }

    public void setStrength(int strength){
        this.strength = strength;
    }

    public void setStability(int stability){
        this.stability = stability;
    }

    public int getValue(int index){
        return values[index];
    }

}
