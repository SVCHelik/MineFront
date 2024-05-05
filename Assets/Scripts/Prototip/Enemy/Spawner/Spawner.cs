using UnityEngine;
using NTC.Pool;
public class Spawner : MonoBehaviour
{
    float radius;
    private void OnEnable() {
        //EventBus.SpawnAsked += spawn; 
    }

    private void OnDisable() {
        //EventBus.SpawnAsked -= spawn;
    }
    private void Start()
    {
        radius = GetComponent<SphereCollider>().radius*transform.lossyScale.x;
    }

    public void spawn(GameObject enemyPrefab){
        Vector3 spawnpoint = Random.insideUnitSphere*radius + transform.position;
        spawnpoint.y = transform.position.y;

        NightPool.Spawn(enemyPrefab, spawnpoint, Quaternion.identity);
    }
    
    // public void OnCollisionEnter(Collision other) {
    //     if (other.gameObject.tag == "Terrain"){
    //         EventBus.SpawnAsked -= spawn;
    //     }
    // }
    // void OnCollisionExit(Collision other)
    // {
    //     if (other.gameObject.tag == "Terrain"){
    //         EventBus.SpawnAsked += spawn;
    //     }
    // }

    

}