using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    private WeaponScriptable weaponToSpawn;

    [SerializeField]
    private Transform weaponSocketLocation;

    private Transform gripIKLocation;

    private bool wasFiring = false;
    private bool firingPressed = false;

    // Components
    public PlayerController controller => playerController;
    private PlayerController playerController;
    public CrosshairScript playerCrosshair;
    private Animator playerAnimator;

    public readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
    public readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
    public readonly int IsFiringHash = Animator.StringToHash("IsFiring");
    public readonly int IsReloadingHash = Animator.StringToHash("IsReloading");
    public readonly int WeaponTypeHash = Animator.StringToHash("WeaponType");

    // Ref
    private Camera viewCamera;
    public WeaponComponent equippedWeapon => weaponComponent;
    private WeaponComponent weaponComponent;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        if(playerController)
        {
            playerCrosshair = playerController.Crosshair;
        }

        viewCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(weaponToSpawn)
            EquipWeapon(weaponToSpawn);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (gripIKLocation == null)
            return;

        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, gripIKLocation.position);
    }

    public void OnFire(InputValue pressed)
    {
        firingPressed = pressed.isPressed;

        if(firingPressed)
            StartFiring();
        else
            StopFiring();
    }

    public void StartFiring()
    {
        if (equippedWeapon == null)
            return;

        if (equippedWeapon.weaponStats.bulletsAvailable <= 0 && equippedWeapon.weaponStats.bulletsInClip <= 0)
            return;

        playerController.isFiring = true;
        playerAnimator.SetBool(IsFiringHash, true);
        equippedWeapon.StartFiringWeapon();
    }

    public void StopFiring()
    {
        if (equippedWeapon == null)
            return;

        playerController.isFiring = false;
        playerAnimator.SetBool(IsFiringHash, false);
        equippedWeapon.StopFiringWeapon();
    }


    public void OnReload(InputValue pressed)
    {
        if (equippedWeapon == null)
            return;

        if (equippedWeapon.weaponStats.bulletsAvailable > 0)
            StartReloading();
    }

    public void StartReloading()
    {
        if (equippedWeapon.weaponStats.bulletsAvailable <= 0)
        {
            if(playerController.isFiring)
                StopFiring();
            return;
        }

        if(playerController.isFiring)
        {
            wasFiring = true;
            StopFiring();
        }

        playerController.isReloading = true;
        playerAnimator.SetBool(IsReloadingHash, true);
        equippedWeapon.StartReloading();

        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }

    public void StopReloading()
    {
        if (playerAnimator.GetBool(IsReloadingHash))
            return;

        playerController.isReloading = false;
        equippedWeapon.StopReloading();
        CancelInvoke(nameof(StopReloading));

        if(wasFiring && firingPressed)
        {
            StartFiring();
            wasFiring = false;
        }
    }

    public void OnLook(InputValue delta)
    {
        Vector2 independentMousePosition = viewCamera.ScreenToViewportPoint(playerCrosshair.CurrentAimPosition);
        //Debug.Log(independentMousePosition);

        playerAnimator.SetFloat(AimHorizontalHash, independentMousePosition.x);
        playerAnimator.SetFloat(AimVerticalHash, independentMousePosition.y);
    }

    public void EquipWeapon(WeaponScriptable weaponScript)
    {
        GameObject spawnedWeapon = Instantiate(weaponScript.itemPrefab, weaponSocketLocation.position, weaponSocketLocation.rotation, weaponSocketLocation);
        if (spawnedWeapon)
        {
            weaponComponent = spawnedWeapon.GetComponent<WeaponComponent>();
            if (equippedWeapon)
            {
                equippedWeapon.Initialize(this, weaponScript);

                PlayerEvents.Invoke_OnWeaponEquippedEvent(equippedWeapon);

                playerAnimator.SetInteger(WeaponTypeHash, (int)equippedWeapon.weaponStats.weaponType);
                gripIKLocation = equippedWeapon.GripLocation;
            }
        }
    }

    public void UnequipWeapon()
    {
        Destroy(equippedWeapon.gameObject);
        weaponComponent = null;
    }
}
