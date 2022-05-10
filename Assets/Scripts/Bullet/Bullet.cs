using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour, IPooleable, IProduct<BulletSO>
{
    [SerializeField] private BulletSO _bulletSo;

    private MeshRenderer _meshRenderer;
    public event PooleableEventHandler Release;
    
    public BulletSO Data
    {
        get => _bulletSo;
        set => _bulletSo = value;
    }

    private Vector3 _direction;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null && ((1<<other.gameObject.layer) & _bulletSo.DamageLayer) != 0)
        {
            damageable.TakeDamage(_bulletSo.Damage, _bulletSo.DamageType);
            Deact();
        }
    }

    private void Update()
    {
        transform.Translate(_direction * (_bulletSo.Speed*Time.deltaTime), Space.World);
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.blue);
    }

    public void Init(Vector3 spawnPosition ,Vector3 direction)
    {
        gameObject.SetActive(true);
        transform.position = spawnPosition;
        _direction = direction;
        Invoke(nameof(Deact), _bulletSo.Lifespan);
        _meshRenderer.material = _bulletSo.Material;
    }

    

    public void Deact()
    {
        Release?.Invoke(this);
        gameObject.SetActive(false);
        
    }

    
}
