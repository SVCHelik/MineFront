using NTC.Pool;
using UnityEngine;

public class Spavner : MonoBehaviour
{
 public GameObject enemyPrefab;
    public int maxEnemy = 5;

    public float timeSpawn = 2f;
    private float timer;

    public float distance = 3;
    Vector3 position;
    
    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemy)
            {
                position = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
                position.Normalize();
                Instantiate(enemyPrefab, position * distance + new Vector3(0,1,0), Quaternion.identity, transform);
            }
        }
    }
}
