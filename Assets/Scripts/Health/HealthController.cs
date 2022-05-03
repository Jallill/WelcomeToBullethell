using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthController : MonoBehaviour, IHealth, IObservable<float>
{
    
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    
    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public float CurrentHealth => _currentHealth;
    
    public List<IObserver<float>> Subscribers => _subscribers;
    private List<IObserver<float>> _subscribers = new List<IObserver<float>>();

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(float value)
    {
        _currentHealth += value;
        NotifyAll(_currentHealth);
    }

    public void ReduceHealth(float value)
    {
        _currentHealth -= value;
        NotifyAll(_currentHealth);
    }
    
    public void Subscribe(IObserver<float> observer)
    {
        if (_subscribers.Contains(observer)) return;

        _subscribers.Add(observer);
    }

    public void Unsubscribe(IObserver<float> observer)
    {
        if (!_subscribers.Contains(observer)) return;

        _subscribers.Remove(observer);
    }

    public void NotifyAll(float message, params object[] args)
    {
        if(_subscribers.Count > 0) _subscribers.ForEach((observer) => observer.OnNotify(message));
    }
    
    // TEST
    private void Update()
    {
        if (Keyboard.current.f2Key.wasPressedThisFrame)
        {
            ReduceHealth(10);
        }
    }
}
