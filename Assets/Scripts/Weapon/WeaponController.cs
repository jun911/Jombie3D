using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] Camera fpsCamera;

    public GunWeapon myWeapon;

    private GunWeapon lastWeapon;

    private void Start()
    {
        myWeapon.InitSetting();
        lastWeapon = myWeapon;
    }

    private void Update()
    {
        WeaponChangeProcess();

        // Weapon Changed!
        if (myWeapon != lastWeapon)
        {
            lastWeapon = myWeapon;
            myWeapon.InitSetting();
            myWeapon.ChangeWeapon();
        }

        myWeapon.Using(fpsCamera, hitEffect, muzzleFlash);
    }

    private void WeaponChangeProcess()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            myWeapon = GetComponent<DefaultGun>();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            myWeapon = GetComponent<M4Gun>();
        }
    }
}

