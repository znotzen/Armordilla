using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject bulletHitPrefab;

    public SpriteRenderer spriteToFade;

    void Start()
    {
        bulletHitPrefab.transform.localScale = new Vector3(2,2,3);
        rb.velocity = transform.right * -speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arm")
        {
            Destroy(Instantiate(bulletHitPrefab, this.transform.position, this.transform.rotation), 0.3f);
            Destroy(this.gameObject);
        }
    }


}
