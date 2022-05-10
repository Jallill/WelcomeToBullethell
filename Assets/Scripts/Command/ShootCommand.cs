
using UnityEngine;

public class ShootCommand : ICommand<Vector3>
{
    private BulletSO _bulletSO;
    private Transform _transform;
    
    public ShootCommand(BulletSO bulletSO, Transform transform)
    {
        _bulletSO = bulletSO;
        _transform = transform;
    }
    
    public void Do(Vector3 direction)
    {
        var bullet = BulletPool.Instance.GetBullet(_bulletSO);
        bullet.Init(_transform.position, direction);
    }
}