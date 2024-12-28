using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using static Constants;


public class Spell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] Elements element;
    [SerializeField] int strength;
    [SerializeField] int stability;
    [SerializeField] List<int> values;
    [SerializeField] Item baseItem;
    [SerializeField] List<Item> supportingItems;
    [SerializeField] CanvasGroup canvasGroup;
    

    //[SerializeField] Constants.Values mainAspect;
    
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private Sprite sprite;

    public Spell(Item item){
        Debug.Log("spell called");
        //baseItem = item;
        //int index = Random.Range(1, 12);
        //string nazwa="tal"+index+".png";
        //sprite = Resources.Load<Sprite>("/img/spells/" + nazwa);
        //sprite=Resources.Load<Sprite>("../img/spells/"+nazwa);
        //Debug.Log("item: "+item.gameObject.name+" sprite: "+nazwa);
    }

    public Values calcAspect(){
        if (baseItem == null)
        {
            text.text = "no aspect";
            return Constants.Values.NUA;
        }
        //mainAspect = baseItem.getAspect();
        //text.text = mainAspect.ToString();
        //return mainAspect;
        return Values.NUA;

    }

    public void setMainItem(Item item){
        baseItem = item;
        calcAspect();
    }

    public void OnDrop(PointerEventData eventData){
        //Debug.Log("Dropped "+eventData.pointerDrag.name);
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
    
    
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("BeginDrag");
        //resetItemSlot();
        //image.raycastTarget = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        //Debug.Log("Drag");
        transform.position = eventData.position;
        //transform.anchoredPosition+= eventData.delta;//divide by canvas scaleFactor if movement problems
    }
    public void OnEndDrag(PointerEventData eventData){
        
        //if(eventData.pointerDrag != null){
        //check if it actually dropped in item slot
        //eventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
        //setItemSlot(eventData.pointerDrag.GetComponent<ItemSlot>());
        //Debug.Log("EndDrag");

        //itemSlot=eventData.pointerDrag.GetComponent<ItemSlot>();
        //itemSlot.setItem(this);
        //}else{
        //itemSlot.setItem(null);
        //itemSlot=null;
        //}
        //image.raycastTarget = true;
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
