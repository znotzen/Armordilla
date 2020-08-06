using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 15f;
    public Rigidbody2D rb;
    public GameObject bulletHitPrefab;

    public GameObject armadillo;
    public Animator armadilloAnimator;

    public GameObject Armor;

    void Start()
    {
        armadillo = GameObject.FindGameObjectWithTag("Arm");
        Armor = GameObject.FindGameObjectWithTag("Armor");
        armadilloAnimator = armadillo.GetComponent<Animator>();
        bulletHitPrefab.transform.localScale = new Vector3(2,2,3);
        rb.velocity = transform.right * -speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arm")
        {
            if(armadilloAnimator.GetBool("Brace") == true)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.transform.Rotate(0, 0, 90);
                rb.velocity = transform.right * -speed;
   
            }
            else
            {
                Destroy(Instantiate(bulletHitPrefab, this.transform.position, this.transform.rotation), 0.3f);
                Destroy(this.gameObject);
                if(Armor != null)
                {
                    Destroy(Armor);
                }
                else
                {
                    if (armadillo.transform.rotation == Quaternion.Euler(0,0,0))
                    {
                        armadillo.transform.Rotate(0, 0, 180);
                    }
                    
                }
            }

            
        }
    }


}
