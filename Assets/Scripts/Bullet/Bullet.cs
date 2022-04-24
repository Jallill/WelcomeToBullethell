using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO _bulletSo;

    private Vector3 _direction;

    private void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = _bulletSo.Material;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null && other.gameObject.layer == _bulletSo.DamageLayer)
        {
            damageable.DealDamage(_bulletSo.Damage);
        }    
    }

    private void Update()
    {
        transform.Translate(_direction * (_bulletSo.Speed*Time.deltaTime));
        Debug.DrawLine(transform.position, transform.position + transform.forward*10, Color.blue, 1000f);
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;
        Invoke(nameof(Deact), _bulletSo.Lifespan);
    }

    public void Deact()
    {
        Destroy(gameObject); // Change so it works with pools
    }

}