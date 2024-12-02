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

    [SerializeField] Talisman WIPTalisman;
    
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

    public void makeCharm(){
        Debug.Log("makeCharm");
    }
    
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
        startADay();
    }
    
}
