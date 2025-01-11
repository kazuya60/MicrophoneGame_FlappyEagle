using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Health health;
    public event Action<int> OnHealthChanged;
    public Player(int startingHealth)
    {
        health = new Health(startingHealth);
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
        OnHealthChanged?.Invoke(GetHealth());
    }

    public void Heal(int amount)
    {
        health.Heal(amount);
        OnHealthChanged?.Invoke(GetHealth());
    }

    public int GetHealth()
    {
        return health.GetHealth();
    }

    public bool IsDead()
    {
        return health.IsDead();
    }

    public void ResetDeath()
    {
        health.ResetDead();
    }

    public void ResetHealth()
    {
        health.ResetHealth();
    }

    


}
