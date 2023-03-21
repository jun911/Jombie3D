using System;
using UnityEngine;

public struct Data
{
    public float range;
    public int damage;
    public int maxBullet;
    public string soundEffect;
    public string info;
    public string objName;
    public GunWeapon gunWeapon;
}

public abstract class GunWeapon : MonoBehaviour
{
    public Data data;

    public abstract void InitSetting();

    public virtual void Using(Camera fpsCamera, GameObject hitEffect, ParticleSystem muzzleFlash)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayMuzzleFlash();
            HitProcess(fpsCamera, hitEffect, data.range, data.damage);
        }
    }

    public virtual void ChangeWeapon()
    {
        foreach (Transform child in transform)
        {
            if (child.name == data.objName)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    #region private method
    private void HitProcess(Camera fpsCamera, GameObject hitEffect, float range, int damage)
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);

        if (isHit)
        {
            CreateHitEmpact(hit, hitEffect);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

            if (enemyHealth != null) { enemyHealth.TakeDamage(damage); }
        }
    }

    private void PlayMuzzleFlash()
    {
        GameObject currentWeapon = transform.Find(data.objName).gameObject;

        ParticleSystem muzzleFlash = currentWeapon.transform.Find("Muzzle Flash VFX").GetComponent<ParticleSystem>();
        AudioSource gunSound = currentWeapon.GetComponent<AudioSource>();

        muzzleFlash.Play();
        gunSound.Play();
    }

    private void CreateHitEmpact(RaycastHit hit, GameObject hitEffect)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.transform.forward));
        Destroy(impact, 1);
    } 
    #endregion
}