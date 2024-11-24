using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour{
    
    [SerializeField] int dayNumber;
    [SerializeField] private List<GameObject> clientsForDay;
    [SerializeField] int amountOfClients;
    [SerializeField] GameObject currentClient;

    public void setClientsForDay(List<GameObject> clients){
        Debug.Log("setClientsForDay");
        for (int i = 0; i < amountOfClients; i++){
            //     
                 int index = Random.Range(0, clients.Count);
                 ClientsForDay.Add(clients[index]);
            //     //clientsForToday.Add(clients[index]);
                 Debug.Log("adding client: "+clients[index].name);
                 Debug.Log("added client: "+ClientsForDay[i].name);
            //     //Debug.Log("added client: "+clientsForToday[i].name);
            //     
                 clients.RemoveAt(index);
        }
        
    }

    public void newClient(){
        
        clientsForDay.RemoveAt(0);
    }

    public void setAmountOfClients(int amountOfClients){
        this.amountOfClients = amountOfClients;
    }
    
    
    

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int AmountOfClients{
        get { return AmountOfClients; }
        set { AmountOfClients = value; }
    }
    public int DayNumber{
        get { return dayNumber; }
        set { dayNumber = value; }
        }

    public List<GameObject> ClientsForDay{
        get{ return clientsForDay; }
        set{ clientsForDay = value; }
    }

}
