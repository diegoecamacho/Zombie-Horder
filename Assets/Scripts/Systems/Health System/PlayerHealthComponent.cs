using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        PlayerEvents.Invoke_OnPlayerHealthSet(this);
    }
    
}
