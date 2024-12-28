using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour{
    
    //add cupboard taht holds items??
    //add calendar
    //add cupboard for spells
    
    [SerializeField] private List<GameObject> availableClients;
    
    [SerializeField] private int dayNumber;
    [SerializeField] private int amountOfClients;
    [SerializeField] private List<GameObject> clientsForDay;
    [SerializeField] private GameObject currentClient;
    
    [SerializeField] private List<ItemSlot> itemSlots;
    
    
    [SerializeField] private Day day;
    [SerializeField] private Canvas gameCanvas;

    private void OnEnable(){
        Client.OnLeave += setNewClient;
        Debug.Log("subscribed for client leaving");
    }

    private void OnDisable(){
        Client.OnLeave -= setNewClient;
    }

    private void startADay(){
        //MAKE IT MORE RANDOMIZED, ADD SCRIPTED DAYS (TUTORIAL?)

         Debug.Log("starting a day");
         amountOfClients=Mathf.Min(dayNumber, availableClients.Count);
         setClientsForDay();
         setNewClient();
         dayNumber++;
    }

    private void setNewClient(){
        if (currentClient != null)
        {
            Destroy(currentClient);
            Debug.Log("destroyed client");
        }
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
    private void setClientsForDay(){
        Debug.Log("setClientsForDay "+dayNumber);
        
        //possibly can be removed?
        clientsForDay.Clear();
        
        List<GameObject> clients = new List<GameObject>(availableClients);
        for (int i = 0; i < amountOfClients; i++){
            int index = Random.Range(0, clients.Count);
            clientsForDay.Add(clients[index]);
            Debug.Log("added client: "+clientsForDay[i].name);
            clients.RemoveAt(index);
        }
    }
    private void Start(){
        dayNumber = 1;
        startADay();
    }
    
}
