using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text txtScore;
    public Text txtHighScore;
    public int score;

    public GameObject select;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        txtScore.text = score.ToString();
        txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        select.SetActive(false);
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        if ((Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Vertical") == 1) && select.activeSelf == false)
        {
            select.SetActive(true);
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            select.transform.position = new Vector3(4.44f, 0.68f, 0);
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            select.transform.position = new Vector3(4.4f, 2.06f, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(select.transform.position == new Vector3(4.44f, 0.68f, 0))
            {
                SceneManager.LoadScene("Menu");
            }
            else if(select.transform.position == new Vector3(4.4f, 2.06f, 0))
            {
                SceneManager.LoadScene("Game");
            }
        }
        
    }

    public void BtnTryAgin()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
