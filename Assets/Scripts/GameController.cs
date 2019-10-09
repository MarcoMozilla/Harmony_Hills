using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class GameController : MonoBehaviour
{
    public GameObject completeLevelUI;
    bool gameHasEnded = false;
    public Text upper_text;
    public Text lower_text;
    public void PlayGame()
    {
        SceneManager.LoadScene("MusicSurf");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton16))
            {
                PlayGame();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton17))
            {
                Quit();
            }
        }

        if (SceneManager.GetActiveScene().name == "MusicSurf")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton16))
            {

                Restart();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton17))
            {
                SwitchToMenu();
            }
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart ()
	{
        completeLevelUI.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void OnTriggerEnter()
    {
        EndGame();
    }
    public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
            if (MusicNotes.synchronization >= 30)
            {
                upper_text = completeLevelUI.transform.Find("Level").GetComponent<Text>();
                upper_text.text = "Home";
                lower_text = completeLevelUI.transform.Find("Complete").GetComponent<Text>();
                lower_text.text = "Arrived";
                completeLevelUI.SetActive(true);    
            } else {
                upper_text = completeLevelUI.transform.Find("Level").GetComponent<Text>();
                upper_text.text = "Lost";
                lower_text = completeLevelUI.transform.Find("Complete").GetComponent<Text>();
                lower_text.text = "Try Again";
                completeLevelUI.SetActive(true);
            }
        }
	}
}
