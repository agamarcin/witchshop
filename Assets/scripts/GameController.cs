using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    
    //PRZECHOWUJE AKTUALNIE AKCEPTOWALNY RYTUAŁY???
    
    //add cupboard taht holds items??
    
    //add fction checking current ritual with possible rituals

    [SerializeField] Talisman WIPTalisman;
    [SerializeField] List<GameObject> availableClients;
    [SerializeField] Day day;
    

    public void startADay(){
        //MAKE IT MORE RANDOMIZED, ADD SCRIPTED DAYS (TUTORIAL?)

        
        
         Debug.Log("starting a day");
         day.setAmountOfClients(Mathf.Min(day.DayNumber, availableClients.Count));
         day.setClientsForDay(availableClients);
        // Debug.Log("number of clients for the day: "+day.AmountOfClients);
        // List<GameObject> clients = availableClients;
        // //List<GameObject> clientsForToday = new List<GameObject>();
        // for (int i = 0; i < day.AmountOfClients; i++){
        //     
        //     int index = Random.Range(0, clients.Count);
        //     day.ClientsForDay.Add(clients[index]);
        //     //clientsForToday.Add(clients[index]);
        //     Debug.Log("adding client: "+clients[index].name);
        //     Debug.Log("added client: "+day.ClientsForDay[i].name);
        //     //Debug.Log("added client: "+clientsForToday[i].name);
        //     
        //     clients.RemoveAt(index);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
