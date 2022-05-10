
using UnityEngine;

public class PistolWeapon : Weapon
{
    private BulletPool _bulletPool;
    
    public override void Shoot(Vector3 direction)
    {
        if (OnCooldown) return;
        _shootCommand.Do(_bulletSpawnPosition.forward);
        base.Shoot(direction);
    }
}
