using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private EnemyBulletPattern _extraBulletPatter;

    protected override void Start()
    {
        base.Start();
        _extraBulletPatter.InitShootCommands(_enemySo.Bullets);
    }

    public override void Shoot()
    {
        _enemyBulletPattern.Shoot(Random.Range(0f,1f) > 0.1f ? _enemySo.Bullets[0]: _enemySo.Bullets[2]);
        _extraBulletPatter.Shoot(Random.Range(0f,1f) > 0.1f ? _enemySo.Bullets[1]: _enemySo.Bullets[2]);
    }
}