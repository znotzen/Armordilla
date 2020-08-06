using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy1Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public GameObject Armadillo;

    private float timeBetweenShots = 1.5f; //Could randomize
    private float time = 0;

    //Audio
    public AudioSource audioSource;
    public AudioClip gunFire;
    public float volume = 0.5f;


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Fire();
        //}
        if(Armadillo.GetComponent<ArmadilloMovement>().Cowboy1Shoot == true)
        {
            time += Time.deltaTime;
            if (time > timeBetweenShots)
            {
                time = 0;
                Fire();
            }
        }
    }

    void Fire()
    {
        audioSource.PlayOneShot(gunFire, volume);
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
