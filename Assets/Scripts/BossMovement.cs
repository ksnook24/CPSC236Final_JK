using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public static float healthAmount;

    public GameObject deathEffect;

    private void Start()
    {
        healthAmount = 5.0f;
    }

    public void TakeDamange (int damage)
    {
        healthAmount -= damage;

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
