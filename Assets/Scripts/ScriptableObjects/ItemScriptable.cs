using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{
    NONE,
    WEAPON,
    CONSUMABLE,
    EQUIPMENT,
    AMMO
}

public abstract class ItemScriptable : ScriptableObject
{
    public string itemName = "Item";
    public ItemCategory itemCategory = ItemCategory.NONE;
    public GameObject itemPrefab;
    public bool stackable;
    public int maxStack;

    public delegate void AmountChange();
    public event AmountChange OnAmountChange;

    public delegate void ItemDestroyed();
    public event ItemDestroyed OnItemDestroyed;

    public delegate void ItemDropped();
    public event ItemDropped OnItemDropped;

    public int Amount => m_Amount;
    private int m_Amount = 1;

    public PlayerController playerController { get; private set; }

    public virtual void Initialize(PlayerController controller)
    {
        playerController = controller;
    }

    public abstract void UseItem(PlayerController controller);

    public virtual void DeleteItem(PlayerController controller)
    {
        OnItemDestroyed?.Invoke();
        controller.Inventory.DeleteItem(this);
    }

    public virtual void DropItem(PlayerController controller)
    {
        OnItemDropped?.Invoke();
    }

    public void ChangeAmount(int amount)
    {
        m_Amount += amount;
        OnAmountChange?.Invoke();
    }

    public void SetAmount(int amount)
    {
        m_Amount = amount;
        OnAmountChange?.Invoke();
    }
}
