using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy4Fire : MonoBehaviour
{
    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;
    public GameObject Armadillo;

    public GameObject bulletPrefab;

    private float timeBetweenShots = 2.5f;
    private float time = 0;

    public AudioSource audioSource;
    public AudioClip gunFire;
    public AudioClip shotgunPump;
    public float volume = 0.5f;

    private bool pumpedShotgun = false;


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    Fire();
        //}

        if (Armadillo.GetComponent<ArmadilloMovement>().Cowboy4Shoot == true)
        {
            time += Time.deltaTime;
            if (time > timeBetweenShots - .7f && pumpedShotgun == false)
            {
                //Shotgun pump
                audioSource.PlayOneShot(shotgunPump, 0.6f);
                pumpedShotgun = true;
            }
            if (time > timeBetweenShots)
            {
                time = 0;
                timeBetweenShots = Random.Range(2.5f, 6f);
                pumpedShotgun = false;
                Fire();
            }
        }
    }

    void Fire()
    {
        audioSource.PlayOneShot(gunFire, volume);
        Destroy(Instantiate(bulletPrefab, firePoint1.transform.position, firePoint1.transform.rotation), 1f);
        Destroy(Instantiate(bulletPrefab, firePoint2.transform.position, firePoint2.transform.rotation), 1f);
        Destroy(Instantiate(bulletPrefab, firePoint3.transform.position, firePoint3.transform.rotation), 1f);
    }
}
