using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArmadilloMovement : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator anim;
    public float moveSpeed = 5;
    public bool movement = true;
    public Text txtScore;
    public int score = 0;
    public Transform[] SpawningSpots;
    public Transform[] ScorpionSpawningSpots;
    public GameObject PearPrefab;
    public GameObject ScorpionPrefab;
    public GameObject Armor;
    public bool eating = false;

    //Scorpion
    public bool OnScorpion = false;
    public float ScorpionCount;
    public float MaxSC = 1.5f;
    public ScorpionBar scorpionBar;
    public GameObject Point3;
    public GameObject CurrentScorpion;
    public bool noScorpion;

    //Cowboys shoot
    public bool Cowboy1Shoot = false;
    public bool Cowboy4Shoot = false;

    //Audio
    public AudioSource audioSource;
    public AudioClip pearClip;
    public AudioClip backgroundMusic;
    public AudioClip gameOver;
    public float volume = 0.5f;

    private float direction;
    private float gameOverTime = 0;
    private bool EndGame = false;

    private void Start()
    {
        txtScore.text = score.ToString();
        direction = 0;
        SpawnPear();

        ScorpionCount = 0;
        scorpionBar.SetMaxOnSlider(MaxSC);
        noScorpion = false;

        
    }
    void Update()
    {
        //Update player pref score
        if(PlayerPrefs.GetInt("Score") != score)
        {
            PlayerPrefs.SetInt("Score", score);
        }


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
            if(Armor != null)
            {
                Armor.transform.position = this.transform.position + new Vector3(0, 0.25f, 0);
            }
            
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
            if (Armor != null)
            {
                Armor.transform.position = this.transform.position + new Vector3(0, 0.25f, 0);
            }
                anim.SetFloat("Direction", Input.GetAxisRaw("Horizontal"));
                direction = Input.GetAxisRaw("Horizontal");
        }

        //Armor
        if (movement) //Prevents armor flipping while bracing or eating
        {
            if (Armor != null)
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
            
        }
        
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (Armor != null)
            {
                Armor.transform.position = this.transform.position + new Vector3(0, 0.25f, 0);
            }
        }


        //E = Eat
        //Input.GetKeyDown(KeyCode.E)
        if (Input.GetButtonDown("Fire3"))
        {
            movement = false;
            anim.SetBool("Eat", true);
        }
        if (Input.GetButtonUp("Fire3"))
        {
            movement = true;
            anim.SetBool("Eat", false);
        }

        //Input.GetKeyDown(KeyCode.Space)
        if (Input.GetButtonDown("Fire1"))
        {
            //Brace
            movement = false;
            anim.SetBool("Brace", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //End Brace
            movement = true;
            anim.SetBool("Brace", false);
        }

        //Scorpion
        if (anim.GetBool("Eat") == true && OnScorpion == true)
        {
            ScorpionCount += Time.deltaTime;
            scorpionBar.SetSlider(ScorpionCount);
        }

        if (ScorpionCount > MaxSC && OnScorpion == true)
        {
            noScorpion = true;
            Destroy(CurrentScorpion);
            Instantiate(Point3, this.transform.position, this.transform.rotation);
            UpdateScore(3);
            SpawnScorpion();
        }

        //If armadillo upside-down then gameover
        if (this.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            GameOver();
        }

        if(EndGame == true)
        {
            gameOverTime += Time.deltaTime;
        }
        if(gameOverTime > 1.5f)
        {
            //switch scenes
            SceneManager.LoadScene("GameOver");
        }


            //Temp fix
            if (anim.GetBool("Brace") == true)
        {
            movement = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pear")
        {
            audioSource.PlayOneShot(pearClip, 1);
            UpdateScore(1);
            Destroy(collision.gameObject);
            SpawnPear();
        }
        if (collision.tag == "Scorpion")
        {
            CurrentScorpion = collision.gameObject;
            OnScorpion = true;
        }
        if (collision.tag == "LeftOfScreen")
        {
            Cowboy1Shoot = true;
        }
        if (collision.tag == "RightOfScreen")
        {
            Cowboy4Shoot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Scorpion")
        {
            OnScorpion = false;
        }
        if (collision.tag == "LeftOfScreen")
        {
            Cowboy1Shoot = false;
        }
        if (collision.tag == "RightOfScreen")
        {
            Cowboy4Shoot = false;
        }
    }

    public void UpdateScore(int points)
    {
        score = score + points;
        txtScore.text = score.ToString();
    }

    private void SpawnPear()
    {
        Instantiate(PearPrefab, SpawningSpots[Random.Range(0, 10)].transform.position, PearPrefab.transform.rotation);
        if(noScorpion == true)
        {
            SpawnScorpion();
        }
    }
    public void SpawnScorpion()
    {
        int random = Random.Range(0, 3);
        if(random == 1)
        {
            noScorpion = false;
            Instantiate(ScorpionPrefab, ScorpionSpawningSpots[Random.Range(0, 5)].transform.position, ScorpionPrefab.transform.rotation);
            ScorpionCount = 0;
        }
        else
        {
            return;
        }
        
    }


    //Lining up the armor when he walks
    public void RiseArmor()
    {
        if (Armor != null)
        {
            Armor.transform.position = Armor.transform.position + new Vector3(0,0.06f,0);
        } 
    }
    public void LowerArmor()
    {
        if (Armor != null)
        {
            Armor.transform.position = Armor.transform.position - new Vector3(0, 0.06f, 0);
        } 
    }

    //GameOver
    public void GameOver()
    {
        movement = false;
        audioSource.PlayOneShot(gameOver, volume);

        Cowboy1Shoot = false;
        //Cowboy2Shoot = false;
        //Cowboy3Shoot = false;
        Cowboy4Shoot = false;
        //CowboyHorseShoot = false;

        EndGame = true;
    }

}
