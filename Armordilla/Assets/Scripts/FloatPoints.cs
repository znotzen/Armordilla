using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoints : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;

    public float timeFloating;
    public float maxTime = 1.5f;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void Update()
    {
        if(this.gameObject.tag == "3")
        {
            timeFloating += Time.deltaTime;
            if (timeFloating > maxTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
