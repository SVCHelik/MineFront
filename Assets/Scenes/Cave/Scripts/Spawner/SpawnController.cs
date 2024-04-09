
using UnityEngine;
using NTC.MonoCache;
using NTC.Pool;
using System.Collections.Generic;

public class SpawnController: MonoCache
{
 
    public GameObject enemyPrefab;
    public int maxEnemies = 1000;
    public float timeBetweenSpawns = 0;
    private float timer;

    public Spawner[] spawnPoints;
    public GameObject[] mobs;
    public Dictionary<GameObject, NightGameObjectPool>  pools;
    public float timeAlive = 5;
    public int i;



    private void OnEnable() {
    }
    private void Awake() {
        
    }
    private void Start()
    {
        InvokeRepeating("spawn", 0,  timeBetweenSpawns);
    }

    protected override void Run()
    {

    }
    void spawn(){
        // if (pools.TryGetValue(mobs[i%mobs.Length], out NightGameObjectPool mob)){
        //     if(mob.AllClonesCount < maxEnemies){
        //         EventBus.SpawnAsked?.Invoke(mobs[i%mobs.Length]);
        //     }   
        // }
        
        // else{
        //     EventBus.SpawnAsked?.Invoke(mobs[i%mobs.Length]);
        //     pools.Add(mobs[i%mobs.Length], NightPool.GetPoolByPrefab(mobs[i%mobs.Length]));

        // } 
        EventBus.SpawnAsked?.Invoke(mobs[i%mobs.Length]);
        i++;
        
    }

}