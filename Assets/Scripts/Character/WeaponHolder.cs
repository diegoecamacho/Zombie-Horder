using System;
using Character.UI;
using Parent;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Character
{
    public class WeaponHolder : InputMonoBehaviour
    {
        [Header("Weapon To Spawn"), SerializeField]
        private GameObject WeaponToSpawn;

        [SerializeField] private Transform WeaponSocketLocation;

        private Transform GripIKLocation;
        private bool WasFiring = false;
        private bool FiringPressed = false;
        
        //Components
        public PlayerController Controller => PlayerController;
        private PlayerController PlayerController;
        
        private CrossHairScript PlayerCrosshair;
        private Animator PlayerAnimator;
        
        //Ref
        private Camera ViewCamera;
        private WeaponComponent EquippedWeapon;
        
        private static readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
        private static readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
        private static readonly int IsFiringHash = Animator.StringToHash("IsFiring");
        private static readonly int IsReloadingHash = Animator.StringToHash("IsReloading");
        private static readonly int WeaponTypeHash = Animator.StringToHash("WeaponType");


        private new void Awake()
        {
            base.Awake();
            
            PlayerAnimator = GetComponent<Animator>();
            PlayerController = GetComponent<PlayerController>();
            if (PlayerController)
            {
                PlayerCrosshair = PlayerController.CrossHair;
            }
            
            ViewCamera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            GameObject spawnedWeapon = Instantiate(WeaponToSpawn, WeaponSocketLocation.position, WeaponSocketLocation.rotation, WeaponSocketLocation);
            if (!spawnedWeapon) return;
            
            EquippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
            if (!EquippedWeapon) return;
            
            EquippedWeapon.Initialize(this, PlayerCrosshair);
            
            GripIKLocation = EquippedWeapon.GripLocation;
            PlayerAnimator.SetInteger(WeaponTypeHash, (int)EquippedWeapon.WeaponInformation.WeaponType);
        }

        private void OnAnimatorIK(int layerIndex)
        {
            PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripIKLocation.position);
        }
        
        private void OnFire(InputAction.CallbackContext pressed)
        {
            FiringPressed = pressed.ReadValue<float>() == 1f ? true : false;
            
            if (FiringPressed)
                StartFiring();
            else
                StopFiring();
            
        }

        private void StartFiring()
        {
            //TODO: Weapon Seems to be reloading after no bullets left
            if (EquippedWeapon.WeaponInformation.BulletsAvailable <= 0 &&
                EquippedWeapon.WeaponInformation.BulletsInClip <= 0) return;
       
            PlayerController.IsFiring = true;
            PlayerAnimator.SetBool(IsFiringHash, true);
            EquippedWeapon.StartFiringWeapon();
        }

        private void StopFiring()
        {
            PlayerController.IsFiring = false;
            PlayerAnimator.SetBool(IsFiringHash, false);
            EquippedWeapon.StopFiringWeapon();
        }

        
        private void OnReload(InputValue button)
        {
            StartReloading();
        }

        public void StartReloading()
        {
            if (EquippedWeapon.WeaponInformation.BulletsAvailable <= 0 && PlayerController.IsFiring)
            {
                StopFiring();
                return;
            }

            PlayerController.IsReloading = true;
            PlayerAnimator.SetBool(IsReloadingHash, true);
            EquippedWeapon.StartReloading();
            
            InvokeRepeating(nameof(StopReloading), 0, .1f);
        }
        
        private void StopReloading()
        {
            if (PlayerAnimator.GetBool(IsReloadingHash)) return;
            
            PlayerController.IsReloading = false;
            EquippedWeapon.StopReloading();
            CancelInvoke(nameof(StopReloading));
            
            if (!WasFiring || !FiringPressed) return;
            
            StartFiring();
            WasFiring = false;
        }
        
        private void OnLook(InputAction.CallbackContext obj)
        {
            Vector3 independentMousePosition = ViewCamera.ScreenToViewportPoint(PlayerCrosshair.CurrentAimPosition);
            
            PlayerAnimator.SetFloat(AimHorizontalHash, independentMousePosition.x);
            PlayerAnimator.SetFloat(AimVerticalHash, independentMousePosition.y);
        }
        
        private new void OnEnable()
        {
            base.OnEnable();
            GameInput.PlayerActionMap.Look.performed += OnLook;
            GameInput.PlayerActionMap.Fire.performed += OnFire;
            
        }
        
        private new void OnDisable()
        {
            base.OnDisable();
            GameInput.PlayerActionMap.Look.performed -= OnLook;
            GameInput.PlayerActionMap.Fire.performed -= OnFire;
        }


    }
}
