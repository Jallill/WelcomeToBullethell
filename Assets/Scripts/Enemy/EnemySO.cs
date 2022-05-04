using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy-", menuName = "Enemy", order = 0)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Material _material;

    public float MaxHealth => _maxHealth;
    public Bullet Bullet => _bullet;
    public float MovementSpeed => _movementSpeed;
    public Material Material => _material;
}
