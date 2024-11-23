using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    //PRZECHOWUJE AKTUALNIE AKCEPTOWALNY RYTUAŁY???
    
    //add cupboard taht holds items??
    
    //add fction checking current ritual with possible rituals

    [SerializeField] Talisman WIPTalisman;


    public void resetTalisman(){
        foreach (Item item in WIPTalisman.getSupportingItems())
        {
            item.resetPosition();
        }
        WIPTalisman.getBaseItem().resetPosition();

        WIPTalisman.clearItems();
        WIPTalisman.calcAspect();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
