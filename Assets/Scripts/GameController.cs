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
    private Character char_scpt;
    public GameObject snow_balls_ui;

    private void Start()
    {
        GameObject obj = GameObject.Find("Character");
        char_scpt = obj.GetComponent<Character>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MusicSurf");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton18))
            {
                PlayGame();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton19))
            {
                Quit();
            }
        }

        if (SceneManager.GetActiveScene().name == "MusicSurf")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton18))
            {

                Restart();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton19))
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
            Character.start_time = Time.time;


            if (char_scpt.idx_hidx[0] <= 45) {    
                Character.track = 0;
            }

        }
        completeLevelUI.SetActive(true);
        snow_balls_ui.SetActive(false);
        return;
	}
}
