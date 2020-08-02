using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArmadilloMovement : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator anim;
    public float moveSpeed = 5;
    public bool movement = true;
    public Text txtScore;
    public int score = 0;
    public Transform[] SpawningSpots;
    public GameObject PearPrefab;
    public GameObject Armor;
    public bool eating = false;

    //Audio
    public AudioSource audioSource;
    public AudioClip pearClip;
    public float volume = 0.5f;

    private float direction;

    private void Start()
    {
        txtScore.text = score.ToString();
        direction = 0;
        SpawnPear();
    }
    void Update()
    {

        //Replace all Input.GetAxisRaw("Horizontal") with joystick.Horizontal

        if (movement)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")) * moveSpeed);
        }
        else
        {
            theRB.velocity = new Vector2(0,0);
            anim.SetFloat("Speed", 0);
            Armor.transform.position = this.transform.position + new Vector3(0, 0.25f, 0);
        }

        //Fixing auto flip to left idle animation
        if(Input.GetAxisRaw("Vertical") != 0 && direction == 1)
        {
            anim.SetBool("RunRight", true);
        }
        else
        {
            if (anim.GetBool("RunRight") == true)
            {
                anim.SetBool("RunRight", false);
            } 
        }
        

        //Setting Direction
        if(Input.GetAxisRaw("Horizontal") != 0 && direction != Input.GetAxisRaw("Horizontal"))
        {
                Armor.transform.position = this.transform.position + new Vector3(0, 0.25f, 0);
                anim.SetFloat("Direction", Input.GetAxisRaw("Horizontal"));
                direction = Input.GetAxisRaw("Horizontal");
        }

        //Armor
        if (movement) //Prevents armor flipping while bracing or eating
        {
            if (direction == -1)
            {
                Armor.transform.localScale = new Vector3(1, 1, 1);
            }
            if (direction == 1)
            {
                Armor.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Armor.transform.position = this.transform.position + new Vector3(0, 0.25f, 0);
        }


        //E = Eat
        if (Input.GetKeyDown(KeyCode.E))
        {
            movement = false;
            anim.SetBool("Eat", true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            movement = true;
            anim.SetBool("Eat", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Brace
            movement = false;
            anim.SetBool("Brace", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //End Brace
            movement = true;
            anim.SetBool("Brace", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pear")
        {
            audioSource.PlayOneShot(pearClip, volume);
            UpdateScore(1);
            Destroy(collision.gameObject);
            SpawnPear();
        }
    }

    private void UpdateScore(int points)
    {
        score = score + points;
        txtScore.text = score.ToString();
    }

    private void SpawnPear()
    {
        Instantiate(PearPrefab, SpawningSpots[Random.Range(0, 10)].transform.position, PearPrefab.transform.rotation);
    }


    //Lining up the armor when he walks
    public void RiseArmor()
    {
        Armor.transform.position = Armor.transform.position + new Vector3(0,0.06f,0);
    }
    public void LowerArmor()
    {
        Armor.transform.position = Armor.transform.position - new Vector3(0, 0.06f, 0);
    }

}
