using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TouchMegaExp _touchpadUltimate;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _ultimateBulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;


    public float fireRate = 0.1f;
    public float fireRate2 = 10f;


    public float nextFire2 = 0.0f;

  

    private void Start()
    {  
        
    }

    

    private void Update()
    {
       


        if (_touchpadUltimate.CanFire() && Time.time >= nextFire2)
        {
            nextFire2 = Time.time + fireRate2;
            Instantiate(_ultimateBulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
            GetComponent<AudioSource>().Play();
        }
    }


    
}
