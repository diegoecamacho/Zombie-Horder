using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string StartingMenu = "Main Menu";
    [SerializeField] private string RootMenu = "Main Menu";
    
    private MenuWidget ActiveMenu;
    [SerializeField]
    private Dictionary<string, MenuWidget> Menus = new Dictionary<string, MenuWidget>();

    private void Start()
    {
        DisableAllMenus();
        EnableMenu(StartingMenu);
    }
    
    public void AddMenu(string menuName, MenuWidget menuWidget)
    {
        if (Menus.ContainsKey(menuName))
        {
            Debug.LogError("Menu already exists in dictionary");
            return;
        }
        
        if(menuWidget == null) return;
        Menus.Add(menuName, menuWidget);
    }

    public void EnableMenu(string menuName)
    {
        if (Menus.ContainsKey(menuName))
        {
            DisableActiveMenu();

            ActiveMenu = Menus[menuName];
            ActiveMenu.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Menu not available in Dictionary.");
        }
    }

    public void ReturnToRootMenu()
    {
        EnableMenu(RootMenu);
    }

    private void DisableAllMenus()
    {
        foreach (MenuWidget menu in Menus.Values)
        {
            menu.gameObject.SetActive(false);
        }
    }

    private void DisableActiveMenu()
    {
        if (ActiveMenu)
        {
            ActiveMenu.gameObject.SetActive(false);
        }
    }
}

public abstract class MenuWidget : MonoBehaviour
{
    [SerializeField] private string MenuName;
    protected MenuController MenuController;

    private void Awake()
    {
        MenuController = FindObjectOfType<MenuController>();
        if (MenuController)
        {
            MenuController.AddMenu(MenuName, this);
        }
        else
        {
            Debug.LogError("Menu Controller not found!");
        }
    }

    public void ReturnToRootMenu()
    {
        MenuController.ReturnToRootMenu();
    }
}
