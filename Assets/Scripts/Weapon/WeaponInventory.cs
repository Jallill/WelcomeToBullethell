﻿using System;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private IWeapon[] _weapons = new IWeapon[4];

    private void Awake()
    {
        _weapons[0] = GetComponent<IWeapon>(); // Use factory tu create all the weapons?
    }

    public IWeapon GetWeapon(int index = 0)
    {
        return _weapons[0];
    }
}