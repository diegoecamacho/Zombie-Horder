using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSlotAmountWidget : MonoBehaviour
{
    [SerializeField]
    private TMP_Text amountText;
    
    private ItemScriptable item;

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

    public void Initialize(ItemScriptable _item)
    {
        if(_item.stackable)
        {
            item = _item;
            ShowWidget();
            item.OnAmountChange += OnAmountChange;
            OnAmountChange();
        }
    }

    private void OnAmountChange()
    {
        amountText.text = item.Amount.ToString();
    }

    private void OnDisable()
    {
        if (item)
            item.OnAmountChange -= OnAmountChange;
    }
}
