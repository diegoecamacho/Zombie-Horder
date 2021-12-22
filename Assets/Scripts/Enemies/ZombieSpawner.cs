using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerStateMachine))]
public class ZombieSpawner : MonoBehaviour, ISaveable
{
    public delegate void WaveComplete(SpawnerStateEnum currentState);
    public event WaveComplete OnWaveComplete;

    private bool initialized = false;

    [SerializeField]
    private int numberOfZombiesToSpawn;

    public GameObject[] zombiePrefabs;

    public SpawnVolume[] spawnVolumes;

    public GameObject FollowObject => followObject;
    private GameObject followObject;

    private SpawnerStateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<SpawnerStateMachine>();

        followObject = GameObject.FindGameObjectWithTag("Player");

        ZombieWaveState beginningWave = new ZombieWaveState(this, stateMachine)
        {
            zombiesToSpawn = 5,
            nextState = SpawnerStateEnum.Complete
        };

        stateMachine.AddState(SpawnerStateEnum.Beginner, beginningWave);
        if (!initialized)
        {
            stateMachine.Initialize(SpawnerStateEnum.Beginner);
            initialized = true;
        }
    }

    public void CompleteWave(SpawnerStateEnum nextState)
    {
        OnWaveComplete?.Invoke(nextState);
    }

    public SaveDataBase SaveData()
    {
        SpawnerSaveData saveData = new SpawnerSaveData
        {
            Name = gameObject.name,
            currentState = stateMachine.ActiveEnumState
        };

        return saveData;
    }

    public void LoadData(SaveDataBase saveData)
    {
        SpawnerSaveData spawnerSaveData = (SpawnerSaveData)saveData;
        stateMachine.Initialize(spawnerSaveData.currentState);
        initialized = true;
    }
}

[Serializable]
public class SpawnerSaveData : SaveDataBase
{
    public SpawnerStateEnum currentState;
}
