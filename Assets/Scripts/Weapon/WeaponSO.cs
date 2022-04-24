using UnityEngine;

[CreateAssetMenu(fileName = "Weapon-", menuName = "Weapon", order = 0)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private Bullet _bullet;
    public Bullet Bullet => _bullet;
}
