using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearPoints : MonoBehaviour
{
    public GameObject Point1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arm")
        {
            Destroy(Instantiate(Point1, this.transform.position, this.transform.rotation), 0.3f);
        }
    }
}
