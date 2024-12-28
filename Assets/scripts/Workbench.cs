using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants.Values;

public class Workbench : MonoBehaviour
{
    
    [SerializeField] private ItemSlot baseItemSlot;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private GameObject spell;
    
    public void createSpell(Canvas gameCanvas){
        Debug.Log("makeSpell");

        if (baseItemSlot.getItem() == null){
            Debug.Log("no base item");
            return;
        }
        spell = Resources.Load("prefabs/spells/spell1") as GameObject;
        Spell spellScript = spell.GetComponent<Spell>();
        spellScript.setStrength(baseItemSlot.getItem().getStrength());
        spellScript.setStability(100);
        spellScript.setElement(baseItemSlot.getItem().getElement());
        
        
        
        foreach(ItemSlot itS in itemSlots){
            if(itS.getItem()!=null)
            {
                Item it = itS.getItem();
                spellScript.setValue((int)it.getValue(), it.getStrength());
                it.resetItemSlot();
                Destroy(it.gameObject);
                
            }
        }
        spell=Instantiate(spell, new Vector3(0, 0, 0), Quaternion.identity);
        spell.transform.SetParent(this.transform, false);
        spell.transform.SetSiblingIndex(0);
        transform.position=baseItemSlot.transform.position;
        Item baseItem =baseItemSlot.getItem();
        baseItem.resetItemSlot();
        Destroy(baseItem.gameObject);
    }

}
