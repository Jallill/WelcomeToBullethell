using UnityEngine;

[CreateAssetMenu(fileName = "Weapon-", menuName = "Weapon", order = 0)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private float _rateOfFire;
    
    [SerializeField] private Bullet _bullet;
    public float RateOfFire => _rateOfFire;
    public Bullet Bullet => _bullet;
}
