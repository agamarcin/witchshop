using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Item item;
    public void OnDrop(PointerEventData eventData){
        //Debug.Log("Item dropped to slot");
        Debug.Log("dropped to slot "+gameObject.name);
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
      // canvasGroup.alpha = 0.5f;
       // Debug.Log("Item entered slot");
    }
    public void OnPointerExit(PointerEventData eventData){
       // canvasGroup.alpha = 1;
        //Debug.Log("Item entered slot");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
