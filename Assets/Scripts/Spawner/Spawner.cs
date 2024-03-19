using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UIElements;
public class Spawner : MonoBehaviour
{
    float radius;
    private void OnEnable() {
        EventBus.SpawnAsked += spawn; 
    }

    private void OnDisable() {
        EventBus.SpawnAsked -= spawn;
    }
    private void Start()
    {
        radius = GetComponent<SphereCollider>().radius*transform.lossyScale.x;
    }

    private void Update()
    {

    }
    public void spawn(GameObject enemyPrefab){
        radius = GetComponent<SphereCollider>().radius*transform.lossyScale.x;
        Vector3 spawnpoint = UnityEngine.Random.insideUnitSphere*radius + transform.position;
        spawnpoint.y = transform.position.y;
        Instantiate(enemyPrefab, spawnpoint, Quaternion.identity);
    }
    

}