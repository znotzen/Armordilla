using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy1Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
