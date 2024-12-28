using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    // MAKE SEPARETE CLASS FOR BASE ITEM SLOT
    
    //if item dropped into slot without item
    //if item dropped into slot with item?
    //takin out item (reset to shelf)
    //if dropping spell into slot
    
    
    [SerializeField] private Item item;
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            setItem(eventData.pointerDrag.GetComponent<Item>());
            item.setItemSlot(this);
        }
    }

    public void setItem(Item newItem){
        item = newItem;
    }

    public Item getItem(){
        return item;
    }

   public void OnPointerEnter(PointerEventData eventData){
    }
    public void OnPointerExit(PointerEventData eventData){
    }
}
