using UnityEngine;

public class BulletFactory : MonoBehaviour, IFactory<Bullet, BulletSO>
{
    [SerializeField] private Bullet _bulletPrefab; 
    public Bullet Product => _bulletPrefab;
    public Bullet Create(BulletSO bulletSo)
    {
        Bullet b = Instantiate(_bulletPrefab);
        return b;
    }

    public Bullet[] Create(int quantity, BulletSO bulletSo)
    {
        Bullet[] bullets = new Bullet[quantity];

        for (int i = 0; i < quantity; i++)
        {
            bullets[i] = Create(bulletSo);
        }

        return bullets;
    }
}