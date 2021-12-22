using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryReferences : MonoBehaviour
{
    [SerializeField]
    private List<ItemScriptable> itemList = new List<ItemScriptable>();
    private readonly Dictionary<string, ItemScriptable> itemDictionary = new Dictionary<string, ItemScriptable>();
    
    public static InventoryReferences instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        foreach(ItemScriptable itemScript in itemList)
        {
            itemDictionary.Add(itemScript.name, itemScript);
        }
    }

    public ItemScriptable GetItemReference(string itemName) =>
        itemDictionary.ContainsKey(itemName) ? itemDictionary[itemName] : null;
}
