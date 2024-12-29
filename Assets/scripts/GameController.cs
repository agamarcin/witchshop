using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour{
    
    //add cupboard taht holds items??
    //add calendar
    //add cupboard for spells
    
    [SerializeField] private List<GameObject> availableClients;
    [SerializeField] private List<Preset> availableClientsPreset;
    
    [SerializeField] private int dayNumber;
    [SerializeField] private int amountOfClients;
    [SerializeField] private List<GameObject> clientsForDay;
    [SerializeField] private List<Preset> clientsForDayPreset;
    [SerializeField] private GameObject currentClient;
    
    [SerializeField] private List<ItemSlot> itemSlots;
    
    
    [SerializeField] private Day day;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private TextMeshProUGUI dialogueBox;

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
         amountOfClients = 2;//Mathf.Min(dayNumber, availableClients.Count);
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
        if(clientsForDayPreset.Count>0){
            //currentClient = Instantiate(clientsForDay[0], new Vector3(0, 0, 0), Quaternion.identity);
            currentClient = Resources.Load("prefabs/Clients/Client") as GameObject;
            currentClient=Instantiate(currentClient, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Aplpy client: "+clientsForDayPreset[0].name);
            Debug.Log("applying preset: "+clientsForDayPreset[0].ApplyTo(currentClient.GetComponent<Client>()));
            //currentClient.GetComponent<Client>()=clientsForDayPreset[0];
            currentClient.transform.SetParent(gameCanvas.transform, false);
            currentClient.transform.SetSiblingIndex(1);
            Debug.Log("client entered shop");
            showDialogue(currentClient.GetComponent<Client>().getDialogue());
            clientsForDayPreset.RemoveAt(0);
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
        //clientsForDay.Clear();
        clientsForDayPreset.Clear();
        
        //List<GameObject> clients = new List<GameObject>(availableClients);
        List<Preset> clientsPresets = new List<Preset>(availableClientsPreset);
        for (int i = 0; i < amountOfClients; i++){
            int index = Random.Range(0, clientsPresets.Count);
            clientsForDayPreset.Add(clientsPresets[index]);
            //clientsForDay.Add(clients[index]);
            Debug.Log("adding client: "+clientsPresets[index].name);
            Debug.Log("added client: "+clientsForDayPreset[i].name);
            //clients.RemoveAt(index);
            clientsPresets.RemoveAt(index);
        }
        Debug.Log("clients for day: "+clientsForDayPreset.Count);
    }

    public void showDialogue(/*enum dialogueType,*/ string dialogue){
        //dialogueBox.SetActive(true);
        dialogueBox.text = dialogue;
    }
    private void Start(){
        dayNumber = 1;
        startADay();
    }
    
}
