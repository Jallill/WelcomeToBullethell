using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour, IObserver<float>
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private Slider _healthBar;

    private Camera _mainCamera;
    
    private void Awake()
    {
        _healthController.Subscribe(this);
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.back, _mainCamera.transform.rotation * Vector3.up);
    }

    // Observing HealthController
    public void OnNotify(float message, params object[] args)
    {
        _healthBar.value = message/_healthController.MaxHealth;
    }
}
