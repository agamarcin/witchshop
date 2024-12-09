using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    
    //PRZECHOWUJE AKTUALNIE AKCEPTOWALNY RYTUAŁY???
    
    //add cupboard taht holds items??
    
    //add fction checking current ritual with possible rituals

    [SerializeField] GameObject WIPSpell;
    
    [SerializeField] List<GameObject> availableClients;
    
    
    [SerializeField] int dayNumber;
    [SerializeField] int amountOfClients;
    [SerializeField] private List<GameObject> clientsForDay;
    [SerializeField] private GameObject currentClient;
    
    [SerializeField] private List<ItemSlot> itemSlots;
    
    
    [SerializeField] Day day;
    [SerializeField] Canvas gameCanvas;
    

    public void startADay(){
        //MAKE IT MORE RANDOMIZED, ADD SCRIPTED DAYS (TUTORIAL?)

         Debug.Log("starting a day");
         setAmountOfClients(Mathf.Min(day.DayNumber, availableClients.Count));
         setClientsForDay();
         setNewClient();
             

    }

    public void setNewClient(){
        if(clientsForDay.Count()>0){
            currentClient = Instantiate(clientsForDay[0], new Vector3(0, 0, 0), Quaternion.identity);
            currentClient.transform.SetParent(gameCanvas.transform, false);
            currentClient.transform.SetSiblingIndex(1);
        }
        else
        {
            Debug.Log("No clients available, end the day");
        }
    }
    
    public void setClientsForDay(){
        Debug.Log("setClientsForDay");
        List<GameObject> clients = availableClients;
        for (int i = 0; i < amountOfClients; i++){
            int index = Random.Range(0, clients.Count);
            clientsForDay.Add(clients[index]);
            Debug.Log("adding client: "+clients[index].name);
            Debug.Log("added client: "+clientsForDay[i].name);
            clients.RemoveAt(index);
        }
    }
    
    public void setAmountOfClients(int amountOfClients){
        this.amountOfClients = amountOfClients;
    }

    public void makeSpell(){
        Debug.Log("makeSpell");
        foreach(ItemSlot itS in itemSlots){
            if(itS.getItem()!=null)
            {
                Item it = itS.getItem();
                GameObject temp = Resources.Load("prefabs/spells/spell1") as GameObject;
                WIPSpell = Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity);
                WIPSpell.transform.SetParent(gameCanvas.transform, false);
                WIPSpell.transform.position=itemSlots[0].transform.position;
                //WIPSpell = Instantiate(Resources.Load("MyPrefab") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
                break;
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
                WIPSpell.transform.position=itemSlots[0].transform.position;
                it.resetItemSlot();
                Destroy(it.gameObject);
                */
            }
        }
        //currentClient.transform.SetParent(gameCanvas.transform, false);
        //currentClient.transform.SetSiblingIndex(1);
        
    }
    
    public void resetSpell(){
        //foreach (Item item in WIPSpell.getSupportingItems())
        //{
        //    item.resetPosition();
        //}
        //WIPSpell.getBaseItem().resetPosition();

        //WIPSpell.clearItems();
        //WIPSpell.calcAspect();
    }
    void Start()
    {
        startADay();
    }
    
}
