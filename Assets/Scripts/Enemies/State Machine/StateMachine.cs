using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : MonoBehaviour where T : Enum
{
    public T ActiveEnumState { get; private set; }
    public State<T> currentState { get; private set; }
    protected Dictionary<T, State<T>> States;
    private bool Running;

    private void Awake()
    {
        States = new Dictionary<T, State<T>>();
    }

    public void Initialize(T startingState)
    {
        if (States.ContainsKey(startingState))
        {
            ChangeState(startingState);
        }
    }

    public void AddState(T stateName, State<T> state)
    {
        if (States.ContainsKey(stateName))
            return;

        States.Add(stateName, state);
    }

    public void RemoveState(T stateName)
    {
        if (!States.ContainsKey(stateName))
            return;

        States.Remove(stateName);
    }

    public void ChangeState(T nextState)
    {
        if(Running)
        {
            StopRunningState();
        }

        if (!States.ContainsKey(nextState))
            return;
        
        ActiveEnumState = nextState;
        currentState = States[nextState];
        currentState.Start();

        if(currentState.updateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), 0.0f, currentState.updateInterval);
        }

        Running = true;
    }

    private void StopRunningState()
    {
        Running = false;
        currentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }

    private void IntervalUpdate()
    {
        if(Running)
        {
            currentState.IntervalUpdate();
        }
    }

    private void Update()
    {
        if (Running)
        {
            currentState.Update();
        }
    }

    private void FixedUpdate()
    {
        if (Running)
        {
            currentState.FixedUpdate();
        }
    }
}