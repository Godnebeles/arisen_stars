using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{
    private Vector2 currentPosition;
    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    public float smoothing;
    private int pointerID;
    private bool touched;
    private bool canFire;
    
    
     private void Awake()
     {
         direction = Vector2.zero;
         touched = false;
     }

     public void OnPointerDown ( PointerEventData eventData)
     {
         if (!touched)
         {
             canFire = true;
             origin = eventData.position;
             touched = true;
             pointerID = eventData.pointerId;
         }

     }
     public void OnDrag( PointerEventData eventData)
     {
         if (eventData.pointerId == pointerID) 
         {
             currentPosition = eventData.position; // Текущее нажатие
             Vector2 directionRaw = currentPosition - origin;
             
             direction = directionRaw.normalized;
         }

     }

     public void OnPointerUp(PointerEventData eventData)
     {
         if (eventData.pointerId == pointerID)
         {
             canFire = false;
             direction = Vector3.zero;
             touched = false;
         }

     }
     public Vector2 GetDirection()
     {

         smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
         return smoothDirection;

     } 
    public bool CanFire()
    {
        return canFire;
    }

    


}
