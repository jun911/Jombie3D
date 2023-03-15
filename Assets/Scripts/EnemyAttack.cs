using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 40f;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (playerHealth == null) { return; }

        playerHealth.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}