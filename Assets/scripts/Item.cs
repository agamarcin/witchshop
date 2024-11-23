using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] Constants.Elements element;
    //[SerializeField] Constants.Colors color;
    [SerializeField] Constants.Aspects aspect;
    [SerializeField] Transform transform;
    [SerializeField] int defaultX, defaultY;
    [SerializeField] CanvasGroup canvasGroup;
    
    [SerializeField] private Sprite sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition(){
        transform.position = new Vector3(defaultX, defaultY, 0);
    }
    

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        Debug.Log("Drag");
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("EndDrag");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData){
        throw new System.NotImplementedException();
    }


    public Constants.Aspects getAspect(){
        return aspect;
    }

    public Constants.Elements getElement(){
        return element;
    }

    public int getDefaultX(){
        return defaultX;
    }

    public int getDefaultY(){
        return defaultY;
    }

}
