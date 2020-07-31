using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy4Fire : MonoBehaviour
{
    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;

    public GameObject bulletPrefab;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint1.transform.position, firePoint1.transform.rotation);
        Instantiate(bulletPrefab, firePoint2.transform.position, firePoint2.transform.rotation);
        Instantiate(bulletPrefab, firePoint3.transform.position, firePoint3.transform.rotation);
    }
}
