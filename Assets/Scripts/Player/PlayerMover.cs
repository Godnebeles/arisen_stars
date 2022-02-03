using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMover : MonoBehaviour
{
    private Camera mainCamera;
    private Boundary _boundary;

    [SerializeField] private float _speed;

    public void Start()
    {
        mainCamera = Camera.main;
        _boundary = InitializeBoundary();
    }


    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            MovePlayer(mousePosition);
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
            MovePlayer(touchPosition);
        }
    }

    //private void FixedUpdate()
    //{
    //    GetComponent<Rigidbody>().position = new Vector3
    //       (
    //           Mathf.Clamp(GetComponent<Rigidbody>().position.x, _boundary.xMin, _boundary.xMax),
    //           0.0f,
    //           Mathf.Clamp(GetComponent<Rigidbody>().position.z, _boundary.zMin, _boundary.zMax)
    //       );
    //}

    private void MovePlayer(Vector3 pressedPosition)
    {
        pressedPosition.y = transform.position.y;
        pressedPosition.z += 1f;

        if (pressedPosition.x >= _boundary.xMax)
        {
            pressedPosition.x = _boundary.xMax;
        }
        if (pressedPosition.x <= _boundary.xMin)
        {
            pressedPosition.x = _boundary.xMin;
        }
        if (pressedPosition.z <= _boundary.zMax && pressedPosition.z >= _boundary.zMin)
        {

            transform.position = Vector3.MoveTowards(transform.position, pressedPosition,
                                                     _speed + PlayerPrefs.GetFloat("Speed"));
        }
    }

    private Boundary InitializeBoundary()
    {
        Boundary boundary = new Boundary();

        boundary.zMax = 12f;
        boundary.zMin = -4f;

        if (Screen.width < Screen.height)
        {
            float widthScreen = Screen.width;
            float heightScreen = Screen.height;
            float x = widthScreen / heightScreen * 10f;
            boundary.xMin = -x + 0.6f;
            boundary.xMax = x - 0.6f;
        }
        else
        {
            float widthScreen = Screen.width;
            float heightScreen = Screen.height;
            float x = heightScreen / widthScreen * 10f;
            boundary.xMin = -x - 1.3f;
            boundary.xMax = x + 1.3f;
        }

        return boundary;
    }
}
