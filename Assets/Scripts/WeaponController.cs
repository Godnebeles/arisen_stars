using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }
    
    public void Fire()
    {
        Bullet bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<Bullet>();
        bullet.SetDamage(100);
        audioS.Play();
    }
}

