
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (OnCooldown) return;
        for (int i = -1; i < 2; i++)
        {
            var bullet = Instantiate(_weaponSO.Bullet, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
            var newDirection = Quaternion.AngleAxis(i*30, Vector3.up) * _bulletSpawnPosition.forward;
            bullet.Init(newDirection);
        }
        base.Shoot(direction);
    }
}