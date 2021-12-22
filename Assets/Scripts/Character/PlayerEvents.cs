using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void Invoke_OnWeaponEquippedEvent(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }


    public delegate void OnHealthInitializeEvent(HealthComponent healthComponent);

    public static event OnHealthInitializeEvent OnHealthInitialize;

    public static void Invoke_OnHealthInitialize(HealthComponent healthComponent)
    {
        OnHealthInitialize?.Invoke(healthComponent);
    }
}
