using System;
using UnityEngine;

public class EnemyBulletPattern : MonoBehaviour
{
    [SerializeField] private EnemyBulletPatternSO _enemyBulletPatternSo;

    private float _nextShoot;
    private float _angle;
    
    public void Shoot(Vector3 initialPosition, Quaternion initialDirection, Bullet bullet)
    {
        if (_nextShoot > 0) return;
        for (int i = 0; i < _enemyBulletPatternSo.ShootingQuantity; i++)
        {
            var newDirection = Quaternion.AngleAxis(i*(360/_enemyBulletPatternSo.ShootingQuantity) + _angle, Vector3.up) * Vector3.forward;
            var newBullet = Instantiate(bullet, initialPosition, initialDirection);
            newBullet.Init(newDirection);
        }

        _nextShoot = _enemyBulletPatternSo.ShootingSpeed;
    }

    private void Update()
    {
        _nextShoot -= Time.deltaTime;
        _angle += _enemyBulletPatternSo.AngleSpeed * Time.deltaTime;
    }
}