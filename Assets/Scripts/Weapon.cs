using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;
    [SerializeField][Range(0, 200)] private float range = 100f;
    [SerializeField] private int dmg = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

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
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            CreateHitEmpact(hit);
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

    private void CreateHitEmpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.transform.forward));
        Destroy(impact, 1);
    }
}