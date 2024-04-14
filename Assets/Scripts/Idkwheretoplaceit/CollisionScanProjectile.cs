using UnityEngine;
public class CollisionScanProjectile : Projectile
{
    protected override void OnTargetCollision(Collision collision, IDamageable damageable)
    {
        damageable.ApplyDamage(Damage);
    }
}