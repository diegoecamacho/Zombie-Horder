using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerStateEnum
{
    Beginner,
    Intermediate,
    Expert,
    Complete
}

public class SpawnerStateMachine : StateMachine<SpawnerStateEnum>
{

}