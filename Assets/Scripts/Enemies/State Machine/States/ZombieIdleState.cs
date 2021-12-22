using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieStates
{
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");

    public ZombieIdleState(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {

    }

    public override void Start()
    {
        base.Start();

        ownerZombie.zombieNavMesh.isStopped = true;
        ownerZombie.zombieNavMesh.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(MovementZHash, 0.0f);
    }
}
