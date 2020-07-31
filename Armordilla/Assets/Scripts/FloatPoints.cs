using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoints : MonoBehaviour
{
    public float speed = 0.3f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }
}
