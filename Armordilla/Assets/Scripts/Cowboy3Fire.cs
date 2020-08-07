using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy3Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;

    private float timeBetweenShots = 10f; //Could randomize
    private float time = 0;

    public AudioSource audioSource;
    public AudioClip gunFire;
    public AudioClip Cowboy3Warning;
    public float volume = 0.5f;

    private bool gaveWarning = false;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Fire();
        //}

        time += Time.deltaTime;
        if (time > timeBetweenShots - .5f && gaveWarning == false)
        {
            //Warning
            audioSource.PlayOneShot(Cowboy3Warning, 0.7f);
            gaveWarning = true;
        }
        if (time > timeBetweenShots)
        {
            time = 0;
            gaveWarning = false;
            Fire();
        }
    }

    void Fire()
    {
        audioSource.PlayOneShot(gunFire, volume);
        Destroy(Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation), 1f);
    }
}
