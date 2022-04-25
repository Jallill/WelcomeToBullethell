using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private WeaponInventory _weaponInventory;

    private IWeapon _primaryWeapon;
    
    private void Awake()
    {
        _primaryWeapon = _weaponInventory.GetWeapon(0);
    }

    private void Update()
    {
        
        if(_playerInput.FirePerformed) _primaryWeapon?.Shoot(transform.forward);
    }
}
