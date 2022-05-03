using UnityEngine;

public interface IShield<DamageType>
{
    public DamageType DefenseType { get; }
    public void ActivateShield();
    public void DeactivateShield();
}