using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotEquipWidget : MonoBehaviour
{
    private EquipScriptable equippable;
    [SerializeField]
    private Image enabledImage;

    private void Awake()
    {
        HideWidget();
    }

    public void ShowWidget()
    {
        gameObject.SetActive(true);
    }

    public void HideWidget()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(ItemScriptable item)
    {
        if (!(item is EquipScriptable eqItem))
            return;

        equippable = eqItem;
        ShowWidget();

        equippable.OnEquipStatusChange += OnEquipmentChange;
        OnEquipmentChange();
    }

    private void OnEquipmentChange()
    {
        enabledImage.gameObject.SetActive(equippable.Equipped);
    }

    private void OnDisable()
    {
        if(equippable)
            equippable.OnEquipStatusChange -= OnEquipmentChange;
    }
}
