using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxEnemyHealth = 100;
    [SerializeField] int enemyHealth = 100;

    public void TakeDamage(int dmg)
    {
        enemyHealth -= dmg;

        Debug.Log($"Enemy health remain : {enemyHealth}");

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            
            Debug.Log($"Enemy dead!");
        }
    }
}
