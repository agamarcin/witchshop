using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour{
    
    [SerializeField] private List<Client> clientsForDay;
    [SerializeField] int amountOfClients;
    

    void setClientsForDay(List<Client> clients){
    }
    
    
    
    void setAmountOfClients(int newAmountOfClients){
        amountOfClients = newAmountOfClients;
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
