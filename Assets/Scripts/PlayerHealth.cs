using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        Debug.Log($"Player health remain : {health}");

        if (health <= 0)
        {
            //Destroy(gameObject);

            Debug.Log($"Player dead!");
        }
    }
}
