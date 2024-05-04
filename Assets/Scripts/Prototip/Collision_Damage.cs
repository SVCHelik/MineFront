using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float Damage = 101f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Проверяем, столкнулась ли пуля с врагом
        {
            Enemy enemy = other.GetComponent<Enemy>(); // Получаем скрипт Enemy с объекта врага

            if (enemy != null)
            {
                enemy.ApplyDamage(Damage); // Вызываем функцию ApplyDamage из скрипта Enemy
            }

            Destroy(gameObject); // Уничтожаем пулю
        }
    }
}