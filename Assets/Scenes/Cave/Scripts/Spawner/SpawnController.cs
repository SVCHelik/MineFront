
using UnityEngine;
using NTC.MonoCache;
using NTC.Pool;

public class SpawnController: MonoBehaviour
{
 
    public GameObject enemyPrefab;
    public float spawnSpeed = 0.1f;
    private float timer;

    private Spawner[] spawnPoints;
    public GameObject[] mobs;
    public int i;

    public float maxEnemyHpAll = 1000;
    public float curentEnemyHPAll = 0;

    private void OnEnable() {
        EventBus.MobSpawned += OnMobSpawned;
        EventBus.MobDespawned += OnMobDespawned;
    }

    private void OnDisable() {
        EventBus.MobSpawned -= OnMobSpawned;
        EventBus.MobDespawned -= OnMobDespawned;
    }
    private void Awake() {
        
    }
    private void Start()
    {
        spawnPoints = GetComponentsInChildren<Spawner>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnSpeed)
        {
            timer = 0;
            spawn();
        }
    }
    void spawn(){
        if(curentEnemyHPAll < maxEnemyHpAll){    
            GameObject mob = mobs[i%mobs.Length];
            spawnPoints[i % spawnPoints.Length].spawn(mob);
            i++;
        }
    }

    public void OnMobDespawned(float HP){
        curentEnemyHPAll -= HP;
    }
    public void OnMobSpawned(float HP){
        curentEnemyHPAll += HP;
    }

}