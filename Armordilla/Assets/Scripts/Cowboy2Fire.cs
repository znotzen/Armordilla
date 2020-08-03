﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy2Fire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;

    private float timeBetweenShots = 4f; //Could randomize
    private float time = 0;


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
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
        Destroy(Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation), 1f);
    }
}
