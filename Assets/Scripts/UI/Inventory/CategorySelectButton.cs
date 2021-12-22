using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategorySelectButton : MonoBehaviour
{
    [SerializeField]
    private ItemCategory category;

    // References
    private Button selectButton;
    private InventoryWidget inventoryWidget;

    private void Awake()
    {
        selectButton = GetComponent<Button>();
        selectButton.onClick.AddListener(OnClick);
    }

    public void Initialize(InventoryWidget _inventoryWidget)
    {
        inventoryWidget = _inventoryWidget;
    }

    private void OnClick()
    {
        if (!inventoryWidget)
            return;

        inventoryWidget.SelectCategory(category);
    }
}
