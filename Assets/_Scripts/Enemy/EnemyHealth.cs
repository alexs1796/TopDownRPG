using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{


    public event Action<EnemyHealth> Died;
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;
    private bool isDead;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= damage;

        Debug.Log($"Enemy HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            isDead = true;
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}