using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;
    [SerializeField] private GameObject hitVFX;

    private ScoreBoard scoreBoard;
    private DeathHandler deathHandler;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        deathHandler = gameObject.GetComponent<DeathHandler>();
    }

    public void TakeDamage(float dmg)
    {
        health = (health - dmg) < 0 ? 0 :  health - dmg;
        

        scoreBoard.UpdateScoreBoardPlayerHP(health);
        hitEffect();

        if (health <= 0)
        {
            Debug.Log($"Player dead!");
            deathHandler.PlayerDead();
        }
    }

    private void hitEffect()
    {
        GameObject effect = Instantiate(hitVFX, transform.position, Quaternion.identity);

        Destroy(effect, 1.0f);
    }
}