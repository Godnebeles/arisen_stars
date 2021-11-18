using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Boundary
{

    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{

    

    public float Speed = 10;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.1f;
    public float fireRate2 = 10f;
    public GameObject super_shot;
    public float nextFire = 0.0f;
    public float nextFire2 = 0.0f;


    private Quaternion calibrationQuaternion;
    public TouchPad touchPad;
    public TouchPad areaButton;
    public TouchMegaExp areabutton2;

    private PlayerMover dir;
    AudioSource audio;

    public void Awake()
    {
        
    }
    public void Start()
    {
        
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
            boundary.xMax = x + 1.3f ;
        }

        audio = GetComponent<AudioSource>();

    }

    

    public void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        if (Input.touchCount == 1 && Time.time > nextFire || Input.GetButton("Fire1") && Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();                     
        }
        
        if (areabutton2.CanFire() && Time.time > nextFire2 )
         {
             nextFire2 = Time.time + fireRate2;
             Instantiate(super_shot, shotSpawn.position, shotSpawn.rotation);
             GetComponent<AudioSource>().Play();
         }
        
    }

#if UNITY_IOS || UNITY_ANDROID 
    
        
#endif

    private void FixedUpdate()   
    {


        //Vector2 direction = touchPad.GetDirection();
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        /* GetComponent<Rigidbody>().rotation = Quaternion.Euler // Поворот корабля
             (
                 0f,
                 0f,
                 GetComponent<Rigidbody>().velocity * -tilt
             );*/

        //GetComponent<Rigidbody>().velocity = new Vector3(dir.direction.x, 0f, dir.direction.y) * Speed; 


        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
    }
}
