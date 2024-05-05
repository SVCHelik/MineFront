using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int maxBullets = 5;
    public float orbitRadius = 2f;
    public float Damage = 101f;
    public float rotationSpeed = 50f;
    public float bulletLifetime = 5f;
    public float respawnTime = 2f;

    private List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnAndDestroyBullets());
    }

    IEnumerator SpawnAndDestroyBullets()
    {
        float angleStep = 360f / maxBullets;

        while (true)
        {
            for (int i = 0; i < maxBullets; i++)
            {
                float angle = i * angleStep;
                Vector3 spawnPosition = spawnPoint.position + Quaternion.Euler(0, angle, 0) * (Vector3.forward * orbitRadius);
                GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                newBullet.transform.SetParent(this.transform);
                bullets.Add(newBullet);
                Destroy(newBullet, bulletLifetime);
            }

            yield return new WaitForSeconds(respawnTime);

            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
            bullets.Clear();
        }
    }

    void Update()
    {
        RotateBullets();
    }

    void RotateBullets()
    {
        foreach (GameObject bullet in bullets)
        {
            bullet.transform.RotateAround(spawnPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Проверяем, столкнулась ли пуля с врагом
        {
            Enemy enemy = other.GetComponent<Enemy>(); // Получаем скрипт Enemy с объекта врага

            if (enemy != null)
            {
                enemy.ApplyDamage(Damage); // Вызываем функцию ApplyDamage из скрипта Enemy
            }
        }
    }
}