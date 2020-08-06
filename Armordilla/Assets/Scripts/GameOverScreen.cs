﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void BtnTryAgin()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
