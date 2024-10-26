using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ritual : MonoBehaviour{
    [SerializeField]
    Shape shape;
    [SerializeField]
    List<Item> items;
    [SerializeField]
    private GameController gameController;
    [SerializeField] 
    private UnityEngine.UI.Image imag;
    [SerializeField]
    int numberOfItems;
    [SerializeField] private Constants.Targets currentTarget;


    public void setShape(Shape newShape){
        shape=newShape;
        imag.sprite = newShape.getSprite();
        //returnItems
        numberOfItems=newShape.getNumberOfItems();
        currentTarget = newShape.getTarget();
    }

    private void addItem(Item newItem, int space){
        items[space]=newItem;
    }
    private void removeItem(int space){
        items.RemoveAt(space);
    }

    void Start()
    {
        
       // imag=gameObject.GetComponent<UnityEngine.UI.Image>();
    }

    void Update()
    {
        
    }
}
