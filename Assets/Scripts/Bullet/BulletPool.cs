using System;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private BulletFactory _bulletFactory;
    
    private static BulletPool _instance;
    private Pool<Bullet, BulletSO> _bulletPool;
    
    
    public static BulletPool Instance => _instance;
    

    private void Awake()
    {
        _instance = this;
        _bulletPool = new Pool<Bullet, BulletSO>(_bulletFactory);
    }

    public Bullet GetBullet(BulletSO bulletSO)
    {
        return _instance._bulletPool.Get(bulletSO);
    }

    public void ReleaseBullet(Bullet bullet)
    {
        _instance._bulletPool.Release(bullet);
    }
}
