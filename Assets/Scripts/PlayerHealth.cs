using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;
    [SerializeField] private GameObject hitVFX;

    private ScoreBoard scoreBoard;
    private SceneLoader sceneLoader;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        sceneLoader = new SceneLoader();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        scoreBoard.UpdateScoreBoardPlayerHP(health);
        hitEffect();

        if (health <= 0)
        {
            Debug.Log($"Player dead!");
            sceneLoader.GameOver();
        }
    }

    private void hitEffect()
    {
        GameObject effect = Instantiate(hitVFX, transform.position, Quaternion.identity);

        Destroy(effect, 1.0f);
    }
}