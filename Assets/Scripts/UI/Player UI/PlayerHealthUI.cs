using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text HealthText;
    
    private HealthComponent HealthComponent;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerEvents.OnPlayerHealthSet += OnPlayerHealthSet;
    }

    private void OnPlayerHealthSet(HealthComponent healthcomponent)
    {
        HealthComponent = healthcomponent;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthComponent)
        {
            HealthText.text = HealthComponent.Health.ToString();
        }
    }
}
