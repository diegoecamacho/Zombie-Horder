using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IPausable, ISaveable
{
    [Header("Player States")]
    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool inInventory;

    [Header("Crosshair")]
    [SerializeField]
    private CrosshairScript CrosshairComponent;
    public CrosshairScript Crosshair => CrosshairComponent;

    // Components
    public HealthComponent Health => healthComponent;
    private HealthComponent healthComponent;

    public WeaponHolder WeaponHolder => weaponHolder;
    private WeaponHolder weaponHolder;

    public InventoryComponent Inventory => inventory;
    private InventoryComponent inventory;

    private GameUIController UIController;
    private PlayerInput playerInput;

    private void Awake()
    {
        if (healthComponent == null)
            healthComponent = GetComponent<HealthComponent>();
        if (weaponHolder == null)
            weaponHolder = GetComponent<WeaponHolder>();
        if (inventory == null)
            inventory = GetComponent<InventoryComponent>();

        UIController = FindObjectOfType<GameUIController>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnPauseGame(InputValue value)
    {
        Debug.Log("Pause Game");
        PauseManager.instance.PauseGame();
    }

    public void OnUnpauseGame(InputValue value)
    {
        Debug.Log("Unpause Game");
        PauseManager.instance.UnpauseGame();
    }

    public void OnInventory(InputValue value)
    {
        if(inInventory)
        {
            inInventory = false;
            OpenInventory(false);
        }
        else
        {
            inInventory = true;
            OpenInventory(true);
        }
    }

    private void OpenInventory(bool open)
    {
        if(open)
        {
            PauseManager.instance.PauseGame();
            UIController.EnableInventoryMenu();
        }
        else
        {
            PauseManager.instance.UnpauseGame();
            UIController.EnableGameMenu();
        }
    }

    public void PauseMenu()
    {
        UIController.EnablePauseMenu();

        playerInput.SwitchCurrentActionMap("PauseActionMap");
    }

    public void UnpauseMenu()
    {
        UIController.EnableGameMenu();

        playerInput.SwitchCurrentActionMap("PlayerActionMap");
    }

    public void OnSaveGame(InputValue button)
    {
        SaveSystem.instance.SaveGame();
    }

    public void OnLoadGame(InputValue button)
    {
        SaveSystem.instance.LoadGame();
    }

    public SaveDataBase SaveData()
    {
        Transform playerTransform = transform;
        PlayerSaveData saveData = new PlayerSaveData
        {
            Name = gameObject.name,
            currentHealth = healthComponent.Health,
            position = playerTransform.position,
            rotation = playerTransform.rotation
        };

        List<ItemSaveData> itemSaveList = inventory.GetItemList().Select(item => new ItemSaveData(item)).ToList();

        saveData.itemList = itemSaveList;

        saveData.equippedWeapon = weaponHolder.equippedWeapon ? new WeaponSaveData(weaponHolder.equippedWeapon.weaponStats) : null;

        return saveData;
    }

    public void LoadData(SaveDataBase saveData)
    {
        PlayerSaveData playerData = (PlayerSaveData)saveData;

        if (playerData == null)
            return;

        Transform playerTransform = transform;
        playerTransform.position = playerData.position;
        playerTransform.rotation = playerData.rotation;

        Health.SetCurrentHealth(playerData.currentHealth);

        foreach(ItemSaveData itemSaveData in playerData.itemList)
        {
            ItemScriptable item = InventoryReferences.instance.GetItemReference(itemSaveData.Name);
            inventory.AddItem(item, itemSaveData.amount);
        }

        if (playerData.equippedWeapon == null)
            return;

        WeaponScriptable weaponScript = (WeaponScriptable)inventory.FindItem(playerData.equippedWeapon.Name);
        if (!weaponScript)
            return;
        weaponScript.weaponStats = playerData.equippedWeapon.weaponStats;
        weaponHolder.EquipWeapon(weaponScript);
    }
}

[Serializable]
public class PlayerSaveData : SaveDataBase
{
    public float currentHealth;
    public Vector3 position;
    public Quaternion rotation;

    public WeaponSaveData equippedWeapon;
    public List<ItemSaveData> itemList = new List<ItemSaveData>();
}