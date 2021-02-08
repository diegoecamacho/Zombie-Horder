using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Character.UI;
using UnityEngine;

namespace Weapons
{
    public enum WeaponType
    {
        None,
        Pistol,
        MachineGun
    }

    [Serializable]
    public struct WeaponStats
    {
        public WeaponType WeaponType;
        public string WeaponName;
        public float Damage;
        public int BulletsInClip;
        public int ClipSize;
        public int BulletsAvailable;
        public float FireStartDelay;
        public float FireRate;
        public float FireDistance;
        public bool Repeating;
        public LayerMask WeaponHitLayers;
    }

    public class WeaponComponent : MonoBehaviour
    {
        public Transform GripLocation => GripIKLocation;
        [SerializeField] private Transform GripIKLocation;
  
        public WeaponStats WeaponInformation => WeaponStats;
  
        [SerializeField] protected WeaponStats WeaponStats;

        protected Camera MainCamera;
        protected WeaponHolder WeaponHolder;
        protected CrossHairScript CrosshairComponent;
  
        public bool Firing { get; private set; }
        public bool Reloading { get; private set; }

        private void Awake()
        {
            MainCamera = Camera.main;
        }

        public void Initialize(WeaponHolder weaponHolder, CrossHairScript crossHair)
        {
            WeaponHolder = weaponHolder;
            CrosshairComponent = crossHair;
        }

        public virtual void StartFiringWeapon()
        {
            Firing = true;
            if (WeaponStats.Repeating)
            {
                InvokeRepeating(nameof(FireWeapon), WeaponStats.FireStartDelay, WeaponStats.FireRate);
            }
            else
            {
                FireWeapon();
            }
        } 
  
        public virtual void StopFiringWeapon()
        {
            Firing = false;
            CancelInvoke(nameof(FireWeapon));
        }

        protected virtual void FireWeapon()
        {
            Debug.Log("Firing Weapon");
            WeaponStats.BulletsInClip--;
        }

        public virtual void StartReloading()
        {
            Reloading = true;
            ReloadWeapon();
        }

        public virtual void StopReloading()
        {
            Reloading = false;
        }

        protected virtual void ReloadWeapon()
        {
            int bulletsToReload = WeaponStats.ClipSize - WeaponStats.BulletsAvailable;
            if (bulletsToReload < 0)
            {
                WeaponStats.BulletsInClip = WeaponStats.ClipSize;
                WeaponStats.BulletsAvailable -= WeaponStats.ClipSize;
            }
            else
            {
                WeaponStats.BulletsInClip = WeaponStats.BulletsAvailable;
                WeaponStats.BulletsAvailable = 0;
            }
        }
    }
}