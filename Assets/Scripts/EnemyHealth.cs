using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxEnemyHealth = 100;
    [SerializeField] private int enemyHealth = 100;

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