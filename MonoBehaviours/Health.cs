using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
  private int healthPoints = 100;
  private bool isDead = false;

  public Health(int healthPoints)
  {
    this.healthPoints = healthPoints;
    this.healthPoints = Mathf.Clamp(this.healthPoints, 0, 100);
  }

  public int GetHealth()
  {
    return healthPoints;
  }

  public void TakeDamage(int damage)
  {
    healthPoints = Mathf.Clamp(healthPoints - damage, 0, 100);
    if (healthPoints <= 0)
    {
      isDead = true;
    }
    Debug.Log($"Took {damage} damage. Current health: {healthPoints}");
  }

  public void Heal(int amount)
  {
    healthPoints = Mathf.Clamp(healthPoints + amount, 0, 100);
    Debug.Log($"Healed for {amount}. Current health: {healthPoints}");
  }
  public void DisplayHealth()
  {
    Debug.Log($"Current health : {healthPoints}");
  }

  public bool IsDead()
  {
    return isDead;
  }

  public void ResetDead()
  {
    isDead = false;
  }

  public void ResetHealth()
  {
    healthPoints = GameManager.instance.playerHealth;
  }

}
