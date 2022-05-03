using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShieldInventory : MonoBehaviour
{
    private List<IShield<DamageType>> _shields = new List<IShield<DamageType>>();

    private void Awake()
    {
        _shields = GetComponentsInChildren<IShield<DamageType>>().ToList();
    }

    public IShield<DamageType> GetShield(int index)
    {
        return _shields?[index];
    }
}