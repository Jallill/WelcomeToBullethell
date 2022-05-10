
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (OnCooldown) return;
        for (int i = -1; i < 2; i++)
        {
            var newDirection = Quaternion.AngleAxis(i*30, Vector3.up) * _bulletSpawnPosition.forward;
            _shootCommand.Do(newDirection);
        }
        base.Shoot(direction);
    }
}