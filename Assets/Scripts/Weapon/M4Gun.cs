using UnityEngine;

public class M4Gun : GunWeapon
{
    public override void InitSetting()
    {
        data.maxBullet = 50;
        data.info = "2";
        data.range = 100f;
        data.damage = 50;
        data.objName = "Assault_Rifle_M4";
    }

    public override void Using(Camera fpsCamera, GameObject hitEffect, ParticleSystem muzzleFlash)
    {
        base.Using(fpsCamera, hitEffect, muzzleFlash);
    }

    public override void ChangeWeapon()
    {
        base.ChangeWeapon();
    }
}