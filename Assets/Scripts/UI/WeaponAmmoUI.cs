using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponAmmoUI : MonoBehaviour
{
    WeaponComponent weaponComponent;

    [Header("Weapon UI")]
    public TMP_Text weaponNameText;
    public TMP_Text currentBulletText;
    public TMP_Text maxBulletText;

    private void Update()
    {
        if (!weaponComponent)
            return;

        weaponNameText.text = weaponComponent.weaponStats.weaponName;
        currentBulletText.text = weaponComponent.weaponStats.bulletsInClip.ToString();
        maxBulletText.text = weaponComponent.weaponStats.bulletsAvailable.ToString();
    }

    private void OnWeaponEquipped(WeaponComponent _weaponComponent)
    {
        weaponComponent = _weaponComponent;
    }

    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnDisable()
    {
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
    }
}
