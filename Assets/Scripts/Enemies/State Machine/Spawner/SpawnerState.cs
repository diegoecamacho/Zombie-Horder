using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerState : State<SpawnerStateEnum>
{
    protected ZombieSpawner spawner;
    protected SpawnerState(ZombieSpawner _spawner, SpawnerStateMachine stateMachine) : base(stateMachine)
    {
        spawner = _spawner;
    }

    protected void SpawnZombie()
    {
        GameObject zombieToSpawn = spawner.zombiePrefabs[Random.Range(0, spawner.zombiePrefabs.Length)];
        SpawnVolume spawnVolume = spawner.spawnVolumes[Random.Range(0, spawner.spawnVolumes.Length)];

        if (!spawner.FollowObject)
            return;

        GameObject zombie = Object.Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawner.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(spawner.FollowObject);
        zombie.GetComponent<HealthComponent>().OnDeath += OnZombieDeath;
    }

    protected virtual void OnZombieDeath()
    {

    }
}
