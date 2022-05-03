using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-", menuName = "Enemy", order = 0)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Bullet _bullet;

    public float MaxHealth => _maxHealth;
    public Bullet Bullet => _bullet;
}
