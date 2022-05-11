using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPattern : MonoBehaviour
{
    [SerializeField] private EnemyBulletPatternSO _enemyBulletPatternSo;
    private Dictionary<Bullet, ShootCommand> _shootCommands = new Dictionary<Bullet, ShootCommand>();
    
    private float _nextShoot;
    private float _angle;

    public void InitShootCommands(Bullet[] bullets)
    {
        foreach (var bullet in bullets)
        {
            _shootCommands.Add(bullet, new ShootCommand(bullet.Data, transform));            
        }
    }

    public void Shoot(Bullet bullet)
    {
        if (_nextShoot > 0) return;
        for (int i = 0; i < _enemyBulletPatternSo.ShootingQuantity; i++)
        {
            var newDirection = Quaternion.AngleAxis(i*(360/_enemyBulletPatternSo.ShootingQuantity) + _angle, Vector3.up) * Vector3.forward;
            _shootCommands[bullet].Do(newDirection);
        }

        _nextShoot = _enemyBulletPatternSo.ShootingSpeed;
    }

    private void Update()
    {
        _nextShoot -= Time.deltaTime;
        _angle += _enemyBulletPatternSo.AngleSpeed * Time.deltaTime;
    }
}