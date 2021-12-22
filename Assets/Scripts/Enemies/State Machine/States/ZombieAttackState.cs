using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

    private GameObject followTarget;
    private float attackRange = 2.0f;

    private IDamageable damageableObject;

    public ZombieAttackState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;
        updateInterval = 2.0f;

        damageableObject = followTarget.GetComponent<IDamageable>();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        ownerZombie.zombieNavMesh.isStopped = true;
        ownerZombie.zombieNavMesh.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(MovementZHash, 0.0f);
        ownerZombie.zombieAnimator.SetBool(IsAttackingHash, true);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        damageableObject?.TakeDamage(ownerZombie.ZombieDamage);
    }

    // Update is called once per frame
    public override void Update()
    {
        ownerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);

        float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);

        if (distanceBetween > attackRange)
        {
            stateMachine.ChangeState(ZombieStateType.Follow);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieAnimator.SetBool(IsAttackingHash, false);
    }
}
