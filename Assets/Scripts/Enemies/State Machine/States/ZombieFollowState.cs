using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");

    private readonly GameObject followTarget;

    private const float stopDistance = 1.0f;

    public ZombieFollowState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;
        updateInterval = 2.0f;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        ownerZombie.zombieNavMesh.SetDestination(followTarget.transform.position);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        ownerZombie.zombieNavMesh.SetDestination(followTarget.transform.position);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        ownerZombie.zombieAnimator.SetFloat(MovementZHash, ownerZombie.zombieNavMesh.velocity.normalized.z);

        if (Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position) < stopDistance)
        {
            stateMachine.ChangeState(ZombieStateType.Attack);
            //Debug.Log("Attack State");
        }
    }
}
