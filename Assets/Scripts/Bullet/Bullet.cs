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
    private float _lifeTime;

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
        if (_lifeTime <= 0) Deact();
        transform.Translate(_direction * (_bulletSo.Speed*Time.deltaTime), Space.World);
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.blue);
        _lifeTime -= Time.deltaTime;
    }

    public void Init(Vector3 spawnPosition ,Vector3 direction)
    {
        _lifeTime = _bulletSo.Lifespan;
        gameObject.SetActive(true);
        transform.position = spawnPosition;
        _direction = direction;
        _meshRenderer.material = _bulletSo.Material;
    }

    private void Deact()
    {
        Release?.Invoke(this);
        gameObject.SetActive(false);
        
    }

    
}
