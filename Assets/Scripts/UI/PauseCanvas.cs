using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvas : GameHUDWidget
{
    public void ResumeGame()
    {
        PauseManager.instance.UnpauseGame();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
