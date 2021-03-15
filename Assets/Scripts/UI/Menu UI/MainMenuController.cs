using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MenuWidget
{
    public void OnPlayButtonPressed()
    {
        MenuController.EnableMenu("Load Menu");
    }

    public void OnOptionsButtonPressed()
    {
        MenuController.EnableMenu("Options");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
  
}
