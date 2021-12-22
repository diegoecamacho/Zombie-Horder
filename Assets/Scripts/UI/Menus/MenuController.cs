using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string startingMenu = "Main Menu";
    [SerializeField]
    private string rootMenu = "Main Menu";

    private MenuWidget activeWidget;
    
    private Dictionary<string, MenuWidget> menus = new Dictionary<string, MenuWidget>();

    // Start is called before the first frame update
    void Start()
    {
        DisableAllMenus();
        EnableMenu(startingMenu);

        AppEvents.Invoke_OnMouseCursorEnable(true);
    }

    public void AddMenu(string menuName, MenuWidget widget)
    {
        if (string.IsNullOrEmpty(menuName))
            return;

        if (menus.ContainsKey(menuName))
        {
            Debug.LogError("Menu already exists!");
            return;
        }

        if (widget == null)
            return;

        menus.Add(menuName, widget);
    }

    public void EnableMenu(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
            return;

        if (menus.ContainsKey(menuName))
        {
            DisableActiveMenu();

            activeWidget = menus[menuName];
            activeWidget.EnableWidget();
        }
        else
        {
            Debug.LogError("Menu is not available in Dictionary!");
        }
    }

    public void DisableMenu(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
            return;

        if (menus.ContainsKey(menuName))
        {
            menus[menuName].DisableWidget();
        }
        else
        {
            Debug.LogError("Menu is not available in Dictionary!");
        }
    }

    public void ReturnToRootMenu()
    {
        EnableMenu(rootMenu);
    }

    private void DisableActiveMenu()
    {
        if(activeWidget)
            activeWidget.DisableWidget();
    }

    private void DisableAllMenus()
    {
        foreach(MenuWidget menu in menus.Values)
        {
            menu.DisableWidget();
        }
    }
}
