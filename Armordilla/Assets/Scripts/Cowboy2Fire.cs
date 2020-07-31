using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy2Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
