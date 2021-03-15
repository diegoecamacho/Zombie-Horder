using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using UnityEngine;
using Weapons;

public class PlayerEvents
{
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void Invoke_OnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }
    
    public delegate void PlayerHealthSet(HealthComponent healthComponent);

    public static event PlayerHealthSet OnPlayerHealthSet;

    public static void Invoke_OnPlayerHealthSet(HealthComponent healthComponent)
    {
        OnPlayerHealthSet?.Invoke(healthComponent);
    }
   
}
