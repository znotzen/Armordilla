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

    //Audio
    public AudioSource audioSource;
    public AudioClip pearClip;
    public float volume = 0.5f;

    private float direction;

    private void Start()
    {
        txtScore.text = score.ToString();
        direction = -1;
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
        }
        

        //Setting Direction
        if(Input.GetAxisRaw("Horizontal") != 0 && direction != Input.GetAxisRaw("Horizontal"))
        {
            anim.SetFloat("Direction", Input.GetAxisRaw("Horizontal"));
            direction = Input.GetAxisRaw("Horizontal");
        }

        //E = Eat
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Eat", true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("Eat", false);
        }

        //Q = Roll (Toggle)
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("Roll", true);
        }
        //Temp Fix
        if (Input.GetKey(KeyCode.T))
        {
            anim.SetBool("Roll", false);
        }

        //Touch
        for (int i = 0; i < Input.touchCount; i++)
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[i].position), Vector2.zero);
            if (hit.collider != null && hit.collider.transform.gameObject.name == "BtnBrace" && Input.touches[i].phase == TouchPhase.Began)
            {
                //Brace
                movement = false;
                anim.SetBool("Brace", true);
            }
            if (hit.collider != null && hit.collider.transform.gameObject.name == "BtnBrace" && Input.touches[i].phase == TouchPhase.Ended)
            {
                //End Brace
                movement = true;
                anim.SetBool("Brace", false);
            }
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

}
