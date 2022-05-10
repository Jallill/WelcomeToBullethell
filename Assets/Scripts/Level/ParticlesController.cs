using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour, IObserver<bool>
{
    [SerializeField] private ParticleSystemRenderer _particleSystem;
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private WinCondition _winCondition;

    private void Start()
    {
        _winCondition.Subscribe(this);
    }

    public void OnNotify(bool result, params object[] args)
    {
        _particleSystem.material = result ? _greenMaterial : _redMaterial;
    }
}
