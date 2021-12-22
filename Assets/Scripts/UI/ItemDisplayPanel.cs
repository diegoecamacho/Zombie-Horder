using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSlot;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        WipeChildren();
    }

    public void PopulatePanel(List<ItemScriptable> itemList)
    {
        WipeChildren();

        foreach(ItemScriptable item in itemList)
        {
            ItemSlot slot = Instantiate(itemSlot, rectTransform).GetComponent<ItemSlot>();
            slot.Initialize(item);
        }
    }

    private void WipeChildren()
    {
        foreach (RectTransform child in rectTransform)
        {
            Destroy(child.gameObject);
        }

        rectTransform.DetachChildren();
    }
}
