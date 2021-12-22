using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private GameSaveData gameSaveData;

    private const string FileSaveKey = "FileSaveData";

    public static SaveSystem instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        if (string.IsNullOrEmpty(GameManager.Instance.GameSaveName))
            return;

        if (!PlayerPrefs.HasKey(GameManager.Instance.GameSaveName))
            return;

        string jsonString = PlayerPrefs.GetString(GameManager.Instance.GameSaveName);
        gameSaveData = JsonUtility.FromJson<GameSaveData>(jsonString);

        //LoadGame();
    }

    public void SaveGame()
    {
        gameSaveData ??= new GameSaveData();

        List<ISaveable> saveableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToList();

        ISaveable playerSaveData = saveableObjects.First(monoObject => monoObject is PlayerController);
        gameSaveData.playerSaveData = playerSaveData?.SaveData() as PlayerSaveData;

        SpawnerSaveDataList spawnerList = new SpawnerSaveDataList();
        var spawnerDataList = saveableObjects.OfType<ZombieSpawner>();
        foreach(var spawner in spawnerDataList)
        {
            ISaveable saveObject = spawner.GetComponent<ISaveable>();
            spawnerList.spawnerData.Add(saveObject?.SaveData() as SpawnerSaveData);
        }

        gameSaveData.spawnerSaveDatList = spawnerList;

        string saveDataString = JsonUtility.ToJson(gameSaveData);

        PlayerPrefs.SetString(GameManager.Instance.GameSaveName, saveDataString);

        SaveToFileList();
    }

    public void LoadGame()
    {
        var saveableObjects = FindObjectsOfType<MonoBehaviour>().Where(monoObject => monoObject is ISaveable).ToList();

        ISaveable playerSaveData = saveableObjects.First(monoObject => monoObject is PlayerController) as ISaveable;
        playerSaveData?.LoadData(gameSaveData.playerSaveData);

        foreach(SpawnerSaveData spawnerData in gameSaveData.spawnerSaveDatList.spawnerData)
        {
            ISaveable saveObject = saveableObjects.Find(saveableObject => spawnerData.Name == saveableObject.name) as ISaveable;
            saveObject?.LoadData(spawnerData);
        }
    }

    public void SaveToFileList()
    {
        if(PlayerPrefs.HasKey(FileSaveKey))
        {
            GameDataList dataList = JsonUtility.FromJson<GameDataList>(PlayerPrefs.GetString(FileSaveKey));

            if (dataList.saveFileNames.Contains(GameManager.Instance.GameSaveName))
                return;
            dataList.saveFileNames.Add(GameManager.Instance.GameSaveName);

            PlayerPrefs.SetString(FileSaveKey, JsonUtility.ToJson(dataList));
        }
        else
        {
            GameDataList dataList = new GameDataList();
            dataList.saveFileNames.Add(GameManager.Instance.GameSaveName);

            PlayerPrefs.SetString(FileSaveKey, JsonUtility.ToJson(dataList));
        }
    }
}

[Serializable]
public class GameSaveData
{
    public PlayerSaveData playerSaveData;
    public SpawnerSaveDataList spawnerSaveDatList;

    public GameSaveData()
    {
        playerSaveData = new PlayerSaveData();
    }
}

[Serializable]
public class SpawnerSaveDataList
{
    public List<SpawnerSaveData> spawnerData = new List<SpawnerSaveData>();
}