using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy1Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public GameObject Armadillo;

    private float timeBetweenShots = 1.5f;
    private float time = 0;

    //Audio
    public AudioSource audioSource;
    public AudioClip gunFire;
    public AudioClip Cowboy1Warning;
    public float volume = 0.5f;

    private bool gaveWarning = false;


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Fire();
        //}
        if(Armadillo.GetComponent<ArmadilloMovement>().Cowboy1Shoot == true)
        {
            time += Time.deltaTime;
            if (time > timeBetweenShots - .5f && gaveWarning == false)
            {
                //Warning
                audioSource.PlayOneShot(Cowboy1Warning, 0.7f);
                gaveWarning = true;
            }
            if (time > timeBetweenShots)
            {
                timeBetweenShots = Random.Range(1.5f, 6f);
                time = 0;
                gaveWarning = false;
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
