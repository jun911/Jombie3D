using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxEnemyHealth = 100;
    [SerializeField] private int enemyHealth = 100;

    public void TakeDamage(int dmg)
    {
        Debug.Log("Enemy taken damage : " + dmg);

        BroadcastMessage("OnDamageTaken");
        enemyHealth -= dmg;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}