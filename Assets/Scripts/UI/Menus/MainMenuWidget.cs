using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWidget : MenuWidget
{
    [SerializeField]
    private string startMenuName = "Load Menu";
    [SerializeField]
    private string optionsMenuName = "Options Menu";

    public void OpenStartMenu()
    {
        menuController.EnableMenu(startMenuName);
    }

    public void OpenOptionsMenu()
    {
        menuController.EnableMenu(optionsMenuName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
