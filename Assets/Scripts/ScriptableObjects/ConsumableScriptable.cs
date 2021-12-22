using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 1)]
public class ConsumableScriptable : ItemScriptable
{
    public int effect = 0;

    public override void UseItem(PlayerController controller)
    {
        if (controller.Health.Health >= controller.Health.MaxHealth)
            return;

        controller.Health.HealPlayer(effect);

        ChangeAmount(-1);

        if (Amount <= 0)
            DeleteItem(controller);
    }
}

[Serializable]
public class ItemSaveData : SaveDataBase
{
    public int amount;

    public ItemSaveData(ItemScriptable item)
    {
        Name = item.name;
        amount = item.Amount;
    }
}