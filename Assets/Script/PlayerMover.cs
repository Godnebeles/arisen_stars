using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    
    Vector3 mousePosition;
    Vector3 touchPosition;
    Camera mainCamera;
    bool controlIsActive = true;
    public float speed;
    private float boundaryMin;
    private float boundaryMax;
    public void Start()
    {
        mainCamera = Camera.main;
        if (Screen.width < Screen.height)
        {
            float widthScreen = Screen.width;
            float heightScreen = Screen.height;
            float x = widthScreen / heightScreen * 10f;
            boundaryMin = -x + 0.6f;
            boundaryMax = x - 0.6f;
        }
        else
        {
            float widthScreen = Screen.width;
            float heightScreen = Screen.height;
            float x = heightScreen / widthScreen * 10f;
            boundaryMin = -x - 1.3f;
            boundaryMax = x + 1.3f;
        }



    }

    void FixedUpdate()
    {
        if (controlIsActive)
        {
            
                if (Input.GetMouseButton(0))        
                {
                    
                        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
                        mousePosition.y = transform.position.y;
                        mousePosition.z += 1f;

                        if (mousePosition.x >= boundaryMax)
                        {
                            mousePosition.x = boundaryMax;
                            
                        }
                        if (mousePosition.x <= boundaryMin)
                        {
                            mousePosition.x = boundaryMin;
                        }
                        if (mousePosition.z <= 12f)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed + PlayerPrefs.GetFloat("Speed"));
                        }
                        
                        
            }
                if (Input.touchCount == 1) 
                {
                    Touch touch = Input.touches[0];
                    touchPosition = mainCamera.ScreenToWorldPoint(touch.position);  
                
                    touchPosition.y = transform.position.y;
                    touchPosition.z += 1f;
                    if (touchPosition.x >= boundaryMax)
                    {
                        touchPosition.x = boundaryMax;
                    }
                    if (touchPosition.x <= boundaryMin)
                    {
                        touchPosition.x = boundaryMin;
                    }
                    if (touchPosition.z <= 12f)
                    {
                        
                        transform.position = Vector3.MoveTowards(transform.position, touchPosition, speed + PlayerPrefs.GetFloat("Speed"));
                        
                    }
                
                }
            
        }
    }
}
