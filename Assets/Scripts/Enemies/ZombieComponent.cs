using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ZombieStateMachine), typeof(ZombieHealth))]

public class ZombieComponent : MonoBehaviour
{
    public NavMeshAgent zombieNavMesh { get; private set; }

    public Animator zombieAnimator { get; private set; }

    public ZombieStateMachine stateMachine { get; private set; }

    public GameObject followTarget;

    public float ZombieDamage => damage;
    [SerializeField]
    private float damage;

    [SerializeField]
    private bool _Debug;

    private void Awake()
    {
        zombieNavMesh = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        stateMachine = GetComponent<ZombieStateMachine>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(_Debug)
        {
            Initialize(followTarget);
        }
    }

    public void Initialize(GameObject _followTarget)
    {
        followTarget = _followTarget;

        ZombieIdleState idleState = new ZombieIdleState(this, stateMachine);
        stateMachine.AddState(ZombieStateType.Idle, idleState);

        ZombieFollowState followState = new ZombieFollowState(followTarget, this, stateMachine);
        stateMachine.AddState(ZombieStateType.Follow, followState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, stateMachine);
        stateMachine.AddState(ZombieStateType.Attack, attackState);

        ZombieDeadState deadState = new ZombieDeadState(this, stateMachine);
        stateMachine.AddState(ZombieStateType.Dead, deadState);
        
        stateMachine.Initialize(ZombieStateType.Follow);
    }
}
