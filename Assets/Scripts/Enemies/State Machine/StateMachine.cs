using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }
    protected Dictionary<ZombieStateType, State> States;
    private bool Running;

    private void Awake()
    {
        States = new Dictionary<ZombieStateType, State>();
    }

    public void Initialize(ZombieStateType startingState)
    {
        if (States.ContainsKey(startingState))
        {
            ChanceState(startingState);
        }
        else if(States.ContainsKey(ZombieStateType.Idle))
        {
            ChanceState(ZombieStateType.Idle);
        }
    }

    public void AddState(ZombieStateType stateName, State state)
    {
        if (States.ContainsKey(stateName)) return;
        States.Add(stateName, state);
    }

    public void RemoveState(ZombieStateType stateName)
    {
        if (!States.ContainsKey(stateName)) return;
        States.Remove(stateName);
    }

    public void ChanceState(ZombieStateType nextState)
    {
        if (Running)
        {
            StopRunningState();
        }

        if (!States.ContainsKey(nextState)) return;

        CurrentState = States[nextState];
        CurrentState.Start();

        if (CurrentState.UpdateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate),0.0f, CurrentState.UpdateInterval);
        }

        Running = true;
    }

    private void StopRunningState()
    {
        Running = false;
        CurrentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }

    private void IntervalUpdate()
    {
        if (Running)
        {
            CurrentState.IntervalUpdate();
        }
    }

    private void Update()
    {
        if (Running)
        {
            CurrentState.Update();
        }
    }

    private void FixedUpdate()
    {
        if (Running)
        {
            CurrentState.FixedUpdate();
        }
    }
}