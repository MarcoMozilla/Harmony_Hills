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
        string s = File.ReadAllText("info.txt");
        Movement.mst.text = "Max Score: " + s;
        string resultString = Regex.Match(s, @"\d+").Value;
        Movement.max_score = Int32.Parse(resultString);
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
			Debug.Log("Level Complete");
            completeLevelUI.SetActive(true);
            if (Movement.max_score >= Movement.score)
            {
                int i = Movement.max_score;
                System.IO.File.WriteAllText(@"info.txt", i.ToString());
            }
        }
	}
}
