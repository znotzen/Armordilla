using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private float flapMinTime = 5f;
    private float flapMaxTime = 15f;

    private float flapTimer = 0;
    private float tumbleTimer = 0;

    public Animator VultureAnim;

    private bool TumbleWeedMovement = false;
    public GameObject TumbleWeed;

    public Text txtHighScore;

    private void Start()
    {
        txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        if (flapTimer <= 0)
        {
            VultureAnim.SetTrigger("Flap");
            flapTimer = Random.Range(flapMinTime, flapMaxTime);
        }
        else
        {
            flapTimer -= Time.deltaTime;
        }
        if (tumbleTimer <= 0)
        {
            TumbleWeedMovement = true;
            tumbleTimer = Random.Range(flapMinTime, flapMaxTime);
        }
        else
        {
            tumbleTimer -= Time.deltaTime;
        }

        if (TumbleWeedMovement == true)
        {
            TumbleWeed.transform.position = new Vector3(TumbleWeed.transform.position.x + 6 * Time.deltaTime, TumbleWeed.transform.position.y);
            TumbleWeed.transform.Rotate(0f, 0f, -2f);
        }
        if(TumbleWeed.transform.position.x >= 15)
        {
            TumbleWeedMovement = false;
            TumbleWeed.transform.position = new Vector3(-12.8f, -3.18f);
        }
    }



    public void BtnPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
