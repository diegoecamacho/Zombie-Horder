using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T> where T : Enum
{
    protected StateMachine<T> stateMachine;
    public float updateInterval { get; protected set; } = 1.0f;

    protected State(StateMachine<T> _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Start()
    {

    }

    public virtual void IntervalUpdate()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}

public class ZombieStates : State<ZombieStateType>
{
    protected ZombieComponent ownerZombie;

    public ZombieStates(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(stateMachine)
    {
        ownerZombie = zombie;
    }
}

public enum ZombieStateType
{
    Idle,
    Attack,
    Follow,
    Dead
}