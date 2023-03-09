using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;
    [SerializeField][Range(0, 200)] private float range = 100f;
    [SerializeField] int dmg = 10;

    private void Update()
    {
        WeaponProcessing();
    }

    private void WeaponProcessing()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(dmg);
            }
        }
        else
        {
            return;
        }
    }
}