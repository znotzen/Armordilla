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

    public string menuType = "main";
    public GameObject select;
    public GameObject settingsMenu;
    public GameObject settingsButton;
    public GameObject controlsButton;
    public GameObject controlScheme;
    public GameObject musicSounds;
    public GameObject musicCheck;
    public GameObject soundsCheck;
    public Button PlayBtn;
    public Button ExitBtn;
    public Button SettingsBtn;
    public Button SoundsBtn;
    public Button ControlsBtn;
    public Button MusicCheckBtn;
    public Button SoundsCheckBtn;

    public GameObject quitMenu;
    public Text txtQuit;

    private void Start()
    {
        txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        select.SetActive(false);
        quitMenu.SetActive(false);
        txtQuit.enabled = false;
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

        //Activate selector
        if ((Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Horizontal") == 1) && select.activeSelf == false)
        {
            select.SetActive(true);
        }

        //Moving selector main menu
        if ((Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == -1) && menuType == "main")
        {
            //play
            select.transform.position = new Vector3(-0.15f, -0.525f, 0);
            select.transform.localScale = new Vector3(4.993788f, 5.262601f, 1f);
        }
        if ((Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Horizontal") == 1) && menuType == "main")
        {
            //settings
            select.transform.position = new Vector3(8.024f, 4.118f, 0);
            select.transform.localScale = new Vector3(1.500704f, 4.316876f, 1f);
        }

        //Enter selection main menu
        if (select.transform.position == new Vector3(-0.15f, -0.525f, 0) && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Game");
        }
        if (select.transform.position == new Vector3(8.024f, 4.118f, 0) && Input.GetButtonDown("Fire1"))
        {
            BtnSettings();
        }



        //Moving selector settings menu
        if(menuType == "select" && Input.GetAxisRaw("Vertical") == 1)
        {
            //Settings Button
            select.transform.position = new Vector3(-0.132f, 1.344f, 0);
            select.transform.localScale = new Vector3(8.078966f, 4.984002f, 1f);
        }
        if (menuType == "select" && Input.GetAxisRaw("Vertical") == -1)
        {
            //Controls Button
            select.transform.position = new Vector3(-0.056f, -1.655f, 0);
            select.transform.localScale = new Vector3(8.397242f, 5.214218f, 1f);

        }
        if (menuType == "select" && Input.GetAxisRaw("Horizontal") == 1)
        {
            //Exit Settings Menu Button
            select.transform.position = new Vector3(5.685f, 2.758f, 0);
            select.transform.localScale = new Vector3(1.722043f, 4.675179f, 1f);
        }

        //Enter selection settings menu
        if (menuType == "select" && select.transform.position == new Vector3(5.685f, 2.758f, 0) && Input.GetButtonDown("Fire1"))
        {
            BtnExit();
        }
        if (menuType == "select" && select.transform.position == new Vector3(-0.132f, 1.344f, 0) && Input.GetButtonDown("Fire1"))
        {
            BtnMusicSounds();
        }
        if (menuType == "select" && select.transform.position == new Vector3(-0.056f, -1.655f, 0) && Input.GetButtonDown("Fire1"))
        {
            BtnControls();
        }




        //Moving selector controls menu
        if (menuType == "controls" && Input.GetAxisRaw("Vertical") == 1)
        {
            //Exit Settings Menu Button
            select.transform.position = new Vector3(5.685f, 2.758f, 0);
            select.transform.localScale = new Vector3(1.722043f, 4.675179f, 1f);
        }


        //Enter selection controls menu
        if (menuType == "controls" && select.transform.position == new Vector3(5.685f, 2.758f, 0) && Input.GetButtonDown("Fire1"))
        {
            BtnExit();
        }





        //Moving selector sounds menu
        if (menuType == "sounds" && Input.GetAxisRaw("Horizontal") == 1)
        {
            //Exit Settings Menu Button
            select.transform.position = new Vector3(5.685f, 2.758f, 0);
            select.transform.localScale = new Vector3(1.722043f, 4.675179f, 1f);
        }
        if (menuType == "sounds" && Input.GetAxisRaw("Vertical") == 1)
        {
            //Music Check
            select.transform.position = new Vector3(1.995f, 1.29f, 0);
            select.transform.localScale = new Vector3(1.773451f, 4.950081f, 1f);
        }
        if (menuType == "sounds" && Input.GetAxisRaw("Vertical") == -1)
        {
            //Sounds Check
            select.transform.position = new Vector3(2.01f, -1.11f, 0);
            select.transform.localScale = new Vector3(1.773451f, 4.950081f, 1f);

        }


        //Enter selection sounds menu
        if (menuType == "sounds" && select.transform.position == new Vector3(5.685f, 2.758f, 0) && Input.GetButtonDown("Fire1"))
        {
            BtnExit();
        }
        if (menuType == "sounds" && select.transform.position == new Vector3(1.995f, 1.29f, 0) && Input.GetButtonDown("Fire1") && select.activeSelf == true)
        {
            BtnMusicCheck();
        }
        if (menuType == "sounds" && select.transform.position == new Vector3(2.01f, -1.11f, 0) && Input.GetButtonDown("Fire1") && select.activeSelf == true)
        {
            BtnSoundsCheck();
        }





        //Moving selector when menu changes
        if (select.transform.position == new Vector3(5.685f, 2.758f, 0) && menuType == "main")
        {
            //Move to settings location
            select.transform.position = new Vector3(8.024f, 4.118f, 0);
            select.transform.localScale = new Vector3(1.500704f, 4.316876f, 1f);
        }
        if (select.transform.position == new Vector3(-0.132f, 1.344f, 0) && menuType == "sounds")
        {
            //Move to exit location
            select.transform.position = new Vector3(5.685f, 2.758f, 0);
            select.transform.localScale = new Vector3(1.722043f, 4.675179f, 1f);
        }
        if (select.transform.position == new Vector3(-0.056f, -1.655f, 0) && menuType == "controls")
        {
            //Move to exit location
            select.transform.position = new Vector3(5.685f, 2.758f, 0);
            select.transform.localScale = new Vector3(1.722043f, 4.675179f, 1f);
        }

    }



    public void BtnPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void BtnSettings()
    {
        quitMenu.SetActive(false);
        txtQuit.enabled = false;

        settingsMenu.SetActive(true);
        settingsButton.SetActive(true);
        controlsButton.SetActive(true);

        SettingsBtn.enabled = false;
        ExitBtn.enabled = true;
        SoundsBtn.enabled = true;
        ControlsBtn.enabled = true;
        PlayBtn.enabled = false;
        MusicCheckBtn.enabled = false;
        SoundsCheckBtn.enabled = false;
        menuType = "select";
    }
    public void BtnExit()
    {
        //Exit
        settingsMenu.SetActive(false);
        controlScheme.SetActive(false);
        musicSounds.SetActive(false);

        PlayBtn.enabled = true;
        SettingsBtn.enabled = true;
        ExitBtn.enabled = false;
        SoundsBtn.enabled = false;
        ControlsBtn.enabled = false;
        menuType = "main";
    }
    public void BtnMusicSounds()
    {
        menuType = "sounds";

        //Sounds
        settingsButton.SetActive(false);
        SoundsBtn.enabled = false;
        controlsButton.SetActive(false);
        ControlsBtn.enabled = false;

        MusicCheckBtn.enabled = true;
        SoundsCheckBtn.enabled = true;

        musicSounds.SetActive(true);
    }
    public void BtnControls()
    {
        menuType = "controls";

        //Controls
        settingsButton.SetActive(false);
        controlsButton.SetActive(false);

        controlScheme.SetActive(true);
    }
    public void BtnMusicCheck()
    {
        //Check or uncheck music
        if (musicCheck.activeSelf == true)
        {
            musicCheck.SetActive(false);
        }
        else
        {
            musicCheck.SetActive(true);
        }
    }
    public void BtnSoundsCheck()
    {
        //Check or uncheck sounds
        if (soundsCheck.activeSelf == true)
        {
            soundsCheck.SetActive(false);
        }
        else
        {
            soundsCheck.SetActive(true);
        }
    }
    public void BtnQuitGame()
    {
        if(quitMenu.activeSelf == false)
        {
            quitMenu.SetActive(true);
            txtQuit.enabled = true;
        }
        else
        {
            //Quit Game
            Application.Quit();
        }
    }
}
