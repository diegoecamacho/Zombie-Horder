using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieGameMode : MonoBehaviour
{
    private ZombieSpawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<ZombieSpawner>();
        spawner.OnWaveComplete += OnWaveComplete;
    }

    private void OnWaveComplete(SpawnerStateEnum stateEnum)
    {
        if (stateEnum == SpawnerStateEnum.Complete)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("MenuScene");
        }
    }
}
