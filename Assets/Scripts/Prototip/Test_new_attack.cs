using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform targetObject;
    public float spawnRadius = 1f;
    public int maxBullets = 5;
    public float rotationSpeed = 50f;
    public float orbitSpeed = 20f;
    public int bulletLifetime = 4;
    public int bulletDelay = 14;

    private List<GameObject> bullets = new List<GameObject>();
    private bool delayInProgress = false;

    void Update()
    {
        if (!delayInProgress)
        {
            StartCoroutine(SpawnDelay());
        }
        foreach (Transform bullet in transform)
        {
            bullet.RotateAround(targetObject.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }

    void SpawnAllBullets()
    {
        for (int i = 0; i < 5; i++)
        {
            if (bullets.Count >= maxBullets)
            {
                break;
            }
            float angle = i * 72f;

            Vector3 spawnDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 spawnPosition = targetObject.position + spawnDirection * spawnRadius;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullets.Add(bullet);
            bullet.transform.parent = transform;
            bullet.transform.LookAt(transform.position);
            Destroy(bullet, bulletLifetime);
        }
    }

    IEnumerator SpawnDelay()
    {
        delayInProgress = true;

        yield return new WaitForSeconds(bulletDelay);

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        bullets.Clear();

        SpawnAllBullets();

        delayInProgress = false;
    }

}