using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSlotWidget : MonoBehaviour
{
    private string saveName;

    private GameManager gameManager;

    private LoadMenuWidget loadWidget;

    [SerializeField]
    private TMP_Text saveNameText;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void Initialize(LoadMenuWidget parentWidget, string _saveName)
    {
        loadWidget = parentWidget;
        saveName = _saveName;

        saveNameText.text = saveName;
    }

    public void SelectSave()
    {
        gameManager.SetActiveSave(saveName);
        loadWidget.LoadScene();
    }
}
