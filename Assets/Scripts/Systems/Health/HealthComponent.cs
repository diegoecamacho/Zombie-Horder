using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    public delegate void OnDeathEvent();

    public event OnDeathEvent OnDeath;

    public float Health => currentHealth;
    public float MaxHealth => maxHealth;

    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private ConsumableScriptable PotionItem;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        currentHealth = 50;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy();
    }

    public void HealPlayer(int effect)
    {
        if (currentHealth < MaxHealth)
            currentHealth = Mathf.Clamp(currentHealth + effect, 0, maxHealth);
    }

    public void SetCurrentHealth(float health)
    {
        currentHealth = health;
    }

    public virtual void Destroy()
    {
        OnDeath?.Invoke();
    }

}
