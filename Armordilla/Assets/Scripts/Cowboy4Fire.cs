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

    private float timeBetweenShots = 1.5f; //Could randomize
    private float time = 0;


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    Fire();
        //}

        if (Armadillo.GetComponent<ArmadilloMovement>().Cowboy4Shoot == true)
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
        Destroy(Instantiate(bulletPrefab, firePoint1.transform.position, firePoint1.transform.rotation), 1f);
        Destroy(Instantiate(bulletPrefab, firePoint2.transform.position, firePoint2.transform.rotation), 1f);
        Destroy(Instantiate(bulletPrefab, firePoint3.transform.position, firePoint3.transform.rotation), 1f);
    }
}
