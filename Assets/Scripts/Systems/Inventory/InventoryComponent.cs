using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField]
    private List<ItemScriptable> items = new List<ItemScriptable>();

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public List<ItemScriptable> GetItemList() => items;

    public int GetItemCount() => items.Count;

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemScriptable FindItem(string itemName)
    {
        return items.Find((invItem) => invItem.name == itemName);
    }

    public void AddItem(ItemScriptable item, int amount = 1)
    {
        int itemIndex = items.FindIndex(itemScript => itemScript.name == item.name);
        
        if(itemIndex != -1)
        {
            ItemScriptable listItem = items[itemIndex];

            if(listItem.stackable && listItem.Amount < listItem.maxStack)
                listItem.ChangeAmount(item.Amount);
        }
        else
        {
            if (item == null)
                return;

            ItemScriptable itemClone = Instantiate(item);
            itemClone.Initialize(playerController);
            itemClone.SetAmount(amount <= 1 ? item.Amount : amount);
            items.Add(itemClone);
        }
    }

    public void DeleteItem(ItemScriptable item)
    {
        int itemIndex = items.FindIndex(listItem => listItem.name == item.name);

        if (itemIndex == -1)
            return;

        items.Remove(item);
    }

    public List<ItemScriptable> GetItemsOfCategory(ItemCategory itemCategory)
    {
        if (items == null || items.Count <= 0)
            return null;

        return itemCategory == ItemCategory.NONE ? items : items.FindAll(item => item.itemCategory == itemCategory);
    }
}
