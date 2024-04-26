using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("AItest");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}