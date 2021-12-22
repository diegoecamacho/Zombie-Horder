using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : HealthComponent
{
    private ZombieStateMachine zombieStateMachine;

    private void Awake()
    {
        zombieStateMachine = GetComponent<ZombieStateMachine>();
    }

    public override void Destroy()
    {
        base.Destroy();

        zombieStateMachine.ChangeState(ZombieStateType.Dead);
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
