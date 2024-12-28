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
    //add calendar
    //add cupboard for spells
    
    //add fction checking current ritual with possible rituals

    [SerializeField] GameObject WIPSpell;
    
    [SerializeField] List<GameObject> availableClients;
    
    
    [SerializeField] int dayNumber;
    [SerializeField] int amountOfClients;
    [SerializeField] private List<GameObject> clientsForDay;
    [SerializeField] private int clientNumber;
    [SerializeField] private GameObject currentClient;
    
    [SerializeField] private List<ItemSlot> itemSlots;
    
    
    [SerializeField] Day day;
    [SerializeField] Canvas gameCanvas;

    private void OnEnable(){
        Client.OnLeave += setNewClient;
        Debug.Log("subscribed for client leaving");
        //throw new NotImplementedException();
    }

    void OnDisable(){
        Client.OnLeave -= setNewClient;
        //throw new NotImplementedException();
    }

    public void startADay(){
        //MAKE IT MORE RANDOMIZED, ADD SCRIPTED DAYS (TUTORIAL?)

         Debug.Log("starting a day");
         setAmountOfClients(Mathf.Min(dayNumber, availableClients.Count));
         setClientsForDay();
         setNewClient();
         dayNumber++;

    }

    public void setNewClient(){
        if (currentClient != null)
        {
            Destroy(currentClient);
            Debug.Log("destroyed client");
            
            //client number possibly can be replaced with clientsForDay.RemoveAt(0); when client entering/leaving
            clientNumber++;
            //not used currently
        }
        //if(clientNumber < clientsForDay.Count){
        if(clientsForDay.Count>0){
            currentClient = Instantiate(clientsForDay[0], new Vector3(0, 0, 0), Quaternion.identity);
            currentClient.transform.SetParent(gameCanvas.transform, false);
            currentClient.transform.SetSiblingIndex(1);
            Debug.Log("client entered shop");
            clientsForDay.RemoveAt(0);
            
            
        }
        else
        {
            //leave time for player to experiment with crafting?
            Debug.Log("No clients available, end the day");
            startADay();
            Debug.Log("starting next day");
        }
    }
    
    public void setClientsForDay(){
        Debug.Log("setClientsForDay "+dayNumber);
        
        //possibly can be replaced with clientsForDay.RemoveAt(0); when client entering/leaving
        clientsForDay.Clear();
        
        //List<GameObject> clients = availableClients;
        List<GameObject> clients = new List<GameObject>(availableClients);
        for (int i = 0; i < amountOfClients; i++){
            int index = Random.Range(0, clients.Count);
            clientsForDay.Add(clients[index]);
            //Debug.Log("adding client: "+clients[index].name);
            Debug.Log("added client: "+clientsForDay[i].name);
            clients.RemoveAt(index);
            clientNumber = 0;
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
        dayNumber = 1;
        startADay();
    }
    
}
