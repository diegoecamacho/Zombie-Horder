using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private ItemScriptable item;

    private Button itemButton;
    private TMP_Text itemText;

    private ItemSlotAmountWidget amountWidget;
    private ItemSlotEquipWidget equipWidget;

    private void Awake()
    {
        itemButton = GetComponent<Button>();
        itemText = GetComponentInChildren<TMP_Text>();

        amountWidget = GetComponentInChildren<ItemSlotAmountWidget>();
        equipWidget = GetComponentInChildren<ItemSlotEquipWidget>();
    }

    public void Initialize(ItemScriptable _item)
    {
        item = _item;
        itemText.text = item.itemName;

        amountWidget.Initialize(item);
        equipWidget.Initialize(item);

        itemButton.onClick.AddListener(UseItem);
        item.OnItemDestroyed += OnItemDestroyed;
    }

    public void UseItem()
    {
        Debug.Log($"{item.itemName} - Item Used");
        item.UseItem(item.playerController);
    }

    private void OnItemDestroyed()
    {
        item = null;
        Destroy(gameObject);
    }
}
