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
    public float volume = 0.5f;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Fire();
        //}

        time += Time.deltaTime;
        if (time > timeBetweenShots)
        {
            time = 0;
            Fire();
        }
    }

    void Fire()
    {
        audioSource.PlayOneShot(gunFire, volume);
        Destroy(Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation), 1f);
    }
}
