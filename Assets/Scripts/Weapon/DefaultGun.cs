using UnityEngine;

public class DefaultGun : GunWeapon
{
    public override void InitSetting()
    {
        data.maxBullet = 30;
        data.info = "1";
        data.range = 80f;
        data.damage = 30;
        data.objName = "Carbine";
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