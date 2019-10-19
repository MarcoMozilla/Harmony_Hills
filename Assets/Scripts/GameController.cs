using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class GameController : MonoBehaviour
{
    public GameObject completeLevelUI;
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
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                PlayGame();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Quit();
            }
        }

        if (SceneManager.GetActiveScene().name == "MusicSurf")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {

                Restart();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
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
        //Character.Restart();
    }

    // public void OnTriggerEnter()
    // {
    //     EndGame();
    // }
    public void EndGame (bool win)
	{
		if (win)
		{
            upper_text = completeLevelUI.transform.Find("Level").GetComponent<Text>();
            upper_text.text = "Home";
            lower_text = completeLevelUI.transform.Find("Complete").GetComponent<Text>();
            lower_text.text = "Arrived";
        } else {
            upper_text = completeLevelUI.transform.Find("Level").GetComponent<Text>();
            upper_text.text = "Lost";
            lower_text = completeLevelUI.transform.Find("Complete").GetComponent<Text>();
            lower_text.text = "Try Again";
        }
        completeLevelUI.SetActive(true);
        return;
	}
}
