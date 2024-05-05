using System.Collections.Generic;
using NTC.OverlapSugar;
using NTC.Pool;
using UnityEngine;


public class Bomb : MonoBehaviour {
    public GameObject fireEffect;
    public GameObject explosionEffect;
    public float explosionRadius = 2f;
    public float damage;
    public OverlapSettings overlapSettings;
    private readonly List<IDamageable> _detectedDamageables = new List<IDamageable>(32);


    private void Start() {
        overlapSettings.SetSphereRadius(explosionRadius);
        //explosionEffect.transform.localScale *= explosionRadius;

    }
    private void OnCollisionEnter(Collision other) {
        explode();
    }
    private void explode(){
        explosionEffect.GetComponent<ParticleSystem>().Play();
        fireEffect.SetActive(false);
        TryPerformAttack();
        NightPool.Despawn(gameObject, 1);
    }
    public void TryPerformAttack()
    {
        if (overlapSettings.TryFind(_detectedDamageables))
        {
            _detectedDamageables.ForEach(ApplyDamage);
        }
    }
        
    private void ApplyDamage(IDamageable damageable)
    {
        damageable.ApplyDamage(damage);
    }

    #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            overlapSettings.TryDrawGizmos();
        }
    #endif
}