using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float Damage = 101f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ���������, ����������� �� ���� � ������
        {
            Enemy enemy = other.GetComponent<Enemy>(); // �������� ������ Enemy � ������� �����

            if (enemy != null)
            {
                enemy.ApplyDamage(Damage); // �������� ������� ApplyDamage �� ������� Enemy
            }

            Destroy(gameObject); // ���������� ����
        }
    }
}