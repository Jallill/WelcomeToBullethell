
using UnityEngine;

public interface IDamageable<DamageType>
{
        void DealDamage(float damage, DamageType damageType);
}
