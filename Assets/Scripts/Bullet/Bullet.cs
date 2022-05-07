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
