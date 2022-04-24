using UnityEngine;

[CreateAssetMenu(fileName = "Bullet-", menuName = "Bullet", order = 1)]
public class BulletSO : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifespan;
    [SerializeField] private float _damage;
    [SerializeField] private Material _material;
    [SerializeField] private LayerMask _damageLayer;
    public float Speed => _speed;
    public float Lifespan => _lifespan;
    public float Damage => _damage;
    public Material Material => _material;
    public LayerMask DamageLayer => _damageLayer;
}