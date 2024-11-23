using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Talisman : MonoBehaviour, IDropHandler
{
    [SerializeField] Constants.Elements element;
    [SerializeField] Item baseItem;
    [SerializeField] List<Item> supportingItems;
    

    [SerializeField] Constants.Aspects mainAspect;
    
    [SerializeField] TextMeshProUGUI text;

    public Constants.Aspects calcAspect(){
        if (baseItem == null)
        {
            text.text = "no aspect";
            return Constants.Aspects.LUCK;
        }
        mainAspect = baseItem.getAspect();
        text.text = mainAspect.ToString();
        return mainAspect;
        
    }

    public void setMainItem(Item item){
        baseItem = item;
        calcAspect();
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropped "+eventData.pointerDrag.name);
        setMainItem(eventData.pointerDrag.gameObject.GetComponent<Item>());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void clearItems(){
        supportingItems.Clear();
        setMainItem(null);
    }

   public Item getBaseItem(){
        return baseItem;
    }
    public List<Item> getSupportingItems(){
        return supportingItems;
    }

}
