using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private IWeapon _weapon;
    private void Awake()
    {
            _playerInput.FireEvent += Shoot;
        _weapon = GetComponent<IWeapon>();
    }

    private void Shoot()
    {
        _weapon?.Shoot(transform.forward);
    }
}
