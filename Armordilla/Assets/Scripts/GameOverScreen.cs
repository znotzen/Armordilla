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

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        txtScore.text = score.ToString();
        txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
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
