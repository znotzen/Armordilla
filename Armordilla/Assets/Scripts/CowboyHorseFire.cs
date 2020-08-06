using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyHorseFire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public GameObject Armadillo;
    public GameObject Horse;

    public bool DoNotFace;
    public Quaternion DefaultArmRotation;

    private float timeBetweenShots = 1.5f; //Could randomize
    private float time = 0;

    public AudioSource audioSource;
    public AudioClip gunFire;
    public float volume = 0.5f;

    private void Start()
    {
        DefaultArmRotation = this.transform.rotation;
    }

    void Update()
    {

        time += Time.deltaTime;

        if(time > 1.5f && Horse.GetComponent<Horse>().HorseMoving == true)
        {
            Fire();
            time = 0;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Fire();
        }

        if (DoNotFace)
        {
            this.transform.rotation = DefaultArmRotation;
        }
        else
        {
            FaceArm(40);
        }
        
        
    }

    void Fire()
    {
        audioSource.PlayOneShot(gunFire, volume);
        Destroy(Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation), 1f);
    }

    void FaceArm(int offset)
    {
        var dx = this.transform.position.x - Armadillo.transform.position.x;
        var dy = this.transform.position.y - Armadillo.transform.position.y;
        var radians = Mathf.Atan2(dy, dx);
        var rotateZ = radians * 180 / Mathf.PI + offset;

        this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y, rotateZ);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftOfScreen")
        {
            DoNotFace = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LeftOfScreen")
        {
            DoNotFace = false;
        }
    }
}
