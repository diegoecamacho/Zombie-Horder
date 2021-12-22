using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        UnpauseGame();
    }

    public void PauseGame()
    {
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();

        foreach(IPausable pausable in pausables)
        {
            pausable.PauseMenu();
        }

        Time.timeScale = 0;

        AppEvents.Invoke_OnMouseCursorEnable(true);
    }

    public void UnpauseGame()
    {
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();

        foreach (IPausable pausable in pausables)
        {
            pausable.UnpauseMenu();
        }

        Time.timeScale = 1;

        AppEvents.Invoke_OnMouseCursorEnable(false);
    }
}

interface IPausable
{
    void PauseMenu();

    void UnpauseMenu();
}