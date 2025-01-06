using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;
    [SerializeField] HealthUI _healthUI;

    public UnityEvent OnDie;
    public UnityEvent OnHurt;

    public int CurrentHealth { get; private set; }

    public int MaxHealth { get; set; }

    private void Awake()
    {
        MaxHealth = _maxHealth;
        CurrentHealth = _maxHealth;
    }

    public void UpdateMaxHealth(int maxHealth)
    {
        MaxHealth += maxHealth;
        _healthUI.UpdateMaxHealth(MaxHealth);
    }


    [Button]
    public void TakeDamage()
    {
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        OnHurt?.Invoke();
        CurrentHealth -= damage;
        _healthUI.UpdateSlider(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }


    public void Heal(int heal)
    {
        CurrentHealth += heal;
        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        _healthUI.UpdateSlider(CurrentHealth);
    }

    void Die()
    {
        CurrentHealth = 0;
        OnDie?.Invoke();
        this.enabled = false;
        //Destroy(gameObject, 3f);
    }
}
