using System;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float xMin { get; private set; }
    public float xMax { get; private set; }
    public float zMin{ get; private set; }
    public float zMax{ get; private set; }

    private void Start()
    {
        InitializeBoundary();
    }

    private void InitializeBoundary()
    {
        zMax = 8.8f;
        zMin = -8f;

        float widthScreen = Screen.width;
        float heightScreen = Screen.height;
        float x = 0;

        if (Screen.width < Screen.height)
            x = widthScreen / heightScreen * 10f;
        else
            x = heightScreen / widthScreen * 10f;

        xMin = -x - 0.6f;
        xMax = x + 0.6f;
    }
    
    // if (Screen.width < Screen.height)
    // {
    //     float width = Screen.width;
    //     float height = Screen.height;
    //     float x = width / height * 10f;
    //     boundary.xMin = -x + 0.6f;
    //     boundary.xMax = x - 0.6f;
    // }
    // else
    // {
    //     float width = Screen.width;
    //     float height = Screen.height;
    //     float x = height / width * 10f;
    //     boundary.xMin = -x - 1.3f;
    //     boundary.xMax = x + 1.3f;
    // }
}