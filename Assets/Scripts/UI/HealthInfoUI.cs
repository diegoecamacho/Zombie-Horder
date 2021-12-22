using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthInfoUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text healthText;

    private HealthComponent playerHealthComponent;

    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialize += OnHealthInitialize;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialize -= OnHealthInitialize;
    }

    private void OnHealthInitialize(HealthComponent healthComponent)
    {
        playerHealthComponent = healthComponent;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealthComponent.Health.ToString();
    }
}
