using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Weapons;

public class WeaponAmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text WeaponNameText;
    [SerializeField] private TMP_Text CurrentBulletText;
    [SerializeField] private TMP_Text TotalBulletText;
    
    private WeaponComponent WeaponComponent;

    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnWeaponEquipped(WeaponComponent weaponcomponent)
    {
        WeaponComponent = weaponcomponent;
    }

    private void OnDisable()
    {
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
    }

    private void Update()
    {
        if (!WeaponComponent) return;

        WeaponNameText.text = WeaponComponent.WeaponInformation.WeaponName;
        CurrentBulletText.text = WeaponComponent.WeaponInformation.BulletsInClip.ToString();
        TotalBulletText.text = WeaponComponent.WeaponInformation.BulletsAvailable.ToString();
    }
}
