using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants.Values;

public class workbench : MonoBehaviour
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
                spellScript.setValue((int)it.GetValue(), it.getStrength());
                //WIPSpell = Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity);
                //WIPSpell.transform.SetParent(gameCanvas.transform, false);
                //WIPSpell.transform.position=itemSlots[0].transform.position;
                //WIPSpell = Instantiate(Resources.Load("MyPrefab") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
                //break;
                /*
                Item it = itS.getItem();
                GameObject exampleOne = new GameObject("spell", typeof(Spell));
                exampleOne.GetComponent<Spell>(). = new Spell(it);
                WIPSpell = exampleOne.GetComponent<Spell>();
                Instantiate(WIPSpell, new Vector3(0, 0, 0), Quaternion.identity);
                WIPSpell.transform.SetParent(gameCanvas.transform, false);
                WIPSpell.transform.position=itemSlots[0].transform.position;

                Item it = itS.getItem();
                GameObject exampleOne = new GameObject("spell",new Spell(it));
                //exampleOne.AddComponent<Spell>();
                //Spell temp = new Spell(it);
                WIPSpell = exampleOne.GetComponent<Spell>();
                Instantiate(WIPSpell, new Vector3(0, 0, 0), Quaternion.identity);
                WIPSpell.transform.SetParent(gameCanvas.transform, false);
                WIPSpell.transform.position=itemSlots[0].transform.position;*/
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

        //currentClient.transform.SetParent(gameCanvas.transform, false);
        //currentClient.transform.SetSiblingIndex(1);

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
