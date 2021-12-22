using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsDeadHash = Animator.StringToHash("IsDead");

    public ZombieDeadState(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavMesh.isStopped = true;
        ownerZombie.zombieNavMesh.ResetPath();

        ownerZombie.zombieAnimator.SetFloat(MovementZHash, 0.0f);
        ownerZombie.zombieAnimator.SetBool(IsDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();

        ownerZombie.zombieNavMesh.isStopped = false;

        ownerZombie.zombieAnimator.SetBool(IsDeadHash, false);
    }
}
