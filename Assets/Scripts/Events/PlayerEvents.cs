using System.Collections;
using System.Collections.Generic;
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
   
}
