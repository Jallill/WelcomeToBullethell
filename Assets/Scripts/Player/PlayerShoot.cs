using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private WeaponInventory _weaponInventory;
    
    
    private IWeapon _primaryWeapon;
    private IWeapon _secondaryWeapon;
    
    private void Start()
    {
        _primaryWeapon = _weaponInventory.GetWeapon(0);
        _secondaryWeapon = _weaponInventory.GetWeapon(1);
    }

    private void Update()
    {
        if(!_playerController.IsGrounded()) return;
        if(_playerInput.PrimaryFirePerformed) _primaryWeapon?.Shoot(transform.forward);
        if (_playerInput.SecondaryFirePerformed) _secondaryWeapon?.Shoot(transform.forward);
    }
}
