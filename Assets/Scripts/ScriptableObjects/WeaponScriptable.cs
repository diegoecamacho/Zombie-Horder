using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 2)]
public class WeaponScriptable : EquipScriptable
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController controller)
    {
        if (Equipped)
        {
            controller.WeaponHolder.UnequipWeapon();
        }
        else
        {
            controller.WeaponHolder.EquipWeapon(this);
        }

        base.UseItem(controller);
    }
}

[Serializable]
public class WeaponSaveData : SaveDataBase
{
    public WeaponStats weaponStats;

    public WeaponSaveData(WeaponStats _weaponStats)
    {
        Name = _weaponStats.weaponName;
        weaponStats = _weaponStats;
    }
}