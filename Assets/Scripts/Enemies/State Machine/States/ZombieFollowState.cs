using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    private readonly GameObject FollowTarget;
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private const float StopDistance = 1.5f;
    
    public ZombieFollowState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;
    }
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        OwnerZombie.ZombieNavMesh.SetDestination(FollowTarget.transform.position);

    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        OwnerZombie.ZombieNavMesh.SetDestination(FollowTarget.transform.position);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, OwnerZombie.ZombieNavMesh.velocity.normalized.z);
        
        float distanceBetween = Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position);
       if (distanceBetween< StopDistance)
       {
           StateMachine.ChanceState(ZombieStateType.Attack);
       }
       
       //TODO: Zombie Health < 0 Die.
        
    }
}
