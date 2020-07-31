using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy3Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
