using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour{
    [SerializeField] String name;
    
    [SerializeField] private Sprite sprite;
    
    [SerializeField]Constants.Aspects neededAspect;
    [SerializeField]private int neededValue;

    void randomizeAspectAndValue(){
        neededAspect = (Constants.Aspects)UnityEngine.Random.Range(0, 7);
        neededValue = UnityEngine.Random.Range(1, 10);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        randomizeAspectAndValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
