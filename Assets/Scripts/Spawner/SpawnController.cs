using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnController : MonoBehaviour
{
 
    public GameObject enemyPrefab;
    public int maxEnemies = 1000;
    public float timeBetweenSpawns = 0;
    private float timer;

    public Spawner[] spawnPoints;
    public GameObject[] mobs;
    public float timeAlive = 5;
    public int i;

    private void Start()
    {
    }

    private void Update()
    {
        timer += Time.deltaTime; 

    if (timer >= timeBetweenSpawns){
            timer -= timeBetweenSpawns; 

            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies){
                i++;
                EventBus.SpawnAsked?.Invoke(mobs[i % 6]);
            }
            
        }

    }

}