using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField]
    private int numberOfItems;

    [SerializeField] private Constants.Targets target;
    [SerializeField] 
    private Ritual ritual;
    //[SerializeField]
    //private Color color;
    [SerializeField]
    private Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumberOfItems(){
        return numberOfItems;
    }
    public Sprite getSprite(){
        return sprite;
    }

    public Constants.Targets getTarget(){
        return target;
    }

}
