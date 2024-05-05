using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float meleeDamage = 50f;
    public GameObject attackEffectPrefab; // Префаб визуального эффекта атаки
    public float attackCooldown = 1f; // Задержка между атаками

    private GameObject target;
    private bool canAttack = true;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy") && canAttack)
            {
                target = collider.gameObject;
                StartCoroutine(AttackWithDelay());
            }
        }
    }

    private IEnumerator AttackWithDelay()
    {
        canAttack = false;
        AttackEnemy();
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void AttackEnemy()
    {
        if (target != null)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplyDamage(meleeDamage);
            }

            if (attackEffectPrefab != null)
            {
                GameObject attackEffect = Instantiate(attackEffectPrefab, target.transform.position, Quaternion.identity);
                attackEffect.transform.LookAt(transform); // Поворот объекта визуального эффекта в сторону игрока
                Destroy(attackEffect, 0.3f); // Задержка перед исчезнованием объекта визуального эффекта
            }
        }
    }
}