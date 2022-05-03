using UnityEngine;

[CreateAssetMenu(fileName = "BulletPattern-", menuName = "BulletPattern", order = 0)]
public class EnemyBulletPatternSO : ScriptableObject
{
    [SerializeField] private int _shootingQuantity;
    [SerializeField] private float _angleSpeed;
    [SerializeField] private float _shootingSpeed;

    public int ShootingQuantity => _shootingQuantity;
    public float AngleSpeed => _angleSpeed;
    public float ShootingSpeed => _shootingSpeed;

}
