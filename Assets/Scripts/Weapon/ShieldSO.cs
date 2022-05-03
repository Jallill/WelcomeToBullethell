using UnityEngine;

[CreateAssetMenu(fileName = "Shield-", menuName = "Shield", order = 0)]
public class ShieldSO : ScriptableObject
{
    [SerializeField] private DamageType _defenseType;

    public DamageType DefenseType => _defenseType;
}