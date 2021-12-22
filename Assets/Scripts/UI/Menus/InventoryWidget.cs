using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWidget : GameHUDWidget
{
    private List<CategorySelectButton> categoryButtons;
    private PlayerController playerController;

    private ItemDisplayPanel itemDisplayPanel;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        categoryButtons = GetComponentsInChildren<CategorySelectButton>().ToList();
        itemDisplayPanel = GetComponentInChildren<ItemDisplayPanel>();

        foreach(CategorySelectButton button in categoryButtons)
        {
            button.Initialize(this);
        }
    }

    private void OnEnable()
    {
        if (!playerController || !playerController.Inventory)
            return;

        if (playerController.Inventory.GetItemCount() <= 0)
            return;

        itemDisplayPanel.PopulatePanel(playerController.Inventory.GetItemsOfCategory(ItemCategory.NONE));
    }

    public void SelectCategory(ItemCategory category)
    {
        if (!playerController || !playerController.Inventory)
            return;

        if (playerController.Inventory.GetItemCount() <= 0)
            return;

        itemDisplayPanel.PopulatePanel(playerController.Inventory.GetItemsOfCategory(category));
    }
}
