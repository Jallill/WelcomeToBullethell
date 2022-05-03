using System;
using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ShieldInventory _shieldInventory;

    private IShield<DamageType> _primaryShield;
    private IShield<DamageType> _secondaryShield;

    private IShield<DamageType> _activeShield;

    public IShield<DamageType> ActiveShield => _activeShield;

    private void Start()
    {
        _primaryShield = _shieldInventory.GetShield(0);
        _secondaryShield = _shieldInventory.GetShield(1);
    }
    
    private void Update()
    {
        if (_playerInput.PrimaryFirePerformed)
        {
            _primaryShield.ActivateShield();
            _secondaryShield.DeactivateShield();
            _activeShield = _primaryShield;
        } 
        else if (_playerInput.SecondaryFirePerformed)
        {
            _secondaryShield.ActivateShield();
            _primaryShield.DeactivateShield();
            _activeShield = _secondaryShield;
        }
        else
        {
            _primaryShield.DeactivateShield();
            _secondaryShield.DeactivateShield();
            _activeShield = null;
        }
    }
}