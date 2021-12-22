using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuWidget : MenuWidget
{
    private GameDataList gameData;

    [SerializeField]
    private bool debug;

    private const string SaveFileKey = "FileSaveData";

    [Header("References")]
    public RectTransform loadItemsPanel;
    [SerializeField]
    private InputField newGameInputField;

    [Header("Prefabs")]
    public GameObject saveSlotPrefab;

    [Header("Scene to load")]
    [SerializeField]
    private string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        if(debug)
            SaveDebugData();
        
        WipeChildren();
        LoadGameData();
    }

    private void WipeChildren()
    {
        foreach(Transform saveSlot in loadItemsPanel)
        {
            Destroy(saveSlot.gameObject);
        }
        loadItemsPanel.DetachChildren();
    }

    private void SaveDebugData()
    {
        GameDataList dataList = new GameDataList();
        dataList.saveFileNames.AddRange(new List<string> { "Save1", "Save2", "Save3" });

        PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dataList));
    }

    private void LoadGameData()
    {
        if (!PlayerPrefs.HasKey(SaveFileKey))
            return;

        string jsonString = PlayerPrefs.GetString(SaveFileKey);
        gameData = JsonUtility.FromJson<GameDataList>(jsonString);

        if (gameData.saveFileNames.Count <= 0)
            return;

        foreach(string saveFile in gameData.saveFileNames)
        {
            SaveSlotWidget widget = Instantiate(saveSlotPrefab, loadItemsPanel).GetComponent<SaveSlotWidget>();
            widget.Initialize(this, saveFile);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void CreateNewGame()
    {
        if (string.IsNullOrEmpty(newGameInputField.text))
            return;

        GameManager.Instance.SetActiveSave(newGameInputField.text);
        LoadScene();
    }
}

[Serializable]
class GameDataList
{
    public List<string> saveFileNames = new List<string>();
}
