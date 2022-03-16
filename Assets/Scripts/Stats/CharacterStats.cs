using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class CharacterStats : MonoBehaviour
{
    
    public float maxHealth = 100f;
    public float maxStamina = 100f;
    public float currentHealth;
    public float currentStamina;
    public Stats damage;
    public Stats armor;

    NavMeshAgent agent;
    void Awake()
    {
        currentStamina = maxStamina;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage ");

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
        Destroy(gameObject);
        Debug.Log("Game Over");
    }



    
}
