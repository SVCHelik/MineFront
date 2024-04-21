using UnityEngine;
using NTC.Pool;
using Unity.Mathematics;
using Pixelplacement;

public class SpawningState : State
{
    [SerializeField] private SpawnController spawnController;
    public FogFSM fogData;
    public ParticleSystem.MainModule fogMain;

    GameObject[] spawners;
    float progress = 0;
    float timer;
    private void Start() {
        fogMain = fogData.fog.main;
    }

    private void OnEnable() {
        
        Debug.Log("Spawning");
        //fogFsm.transposer.enabled = false;
        spawners = SpawnPointsInit();
        fogData.spawnController.enabled = true;
        timer = 0;
    }

    private void Update()
    {

        // Check conditions for transitioning to other states
        if (PlayerObserver.getPlayersDist() < fogData.maxDist)
        {
            ChangeState("FollowingState");
        }

        timer += Time.deltaTime;
        if(timer <= fogData.FogChangingDuration){
            fogMain.maxParticles = (int)(fogData.showCurve.Evaluate(timer) * fogData.MaxCount);
            fogData.spawnController.spawnSpeed = fogData.spawnCurve.Evaluate(timer);
        }
        
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        spawnController.enabled = false;
        NightPool.GetPoolByPrefab(fogData.spawnerPrefab).DespawnAllClones();
        for (int i = 0; i< fogData.fogMobs.Length; i++){
            NightPool.GetPoolByPrefab(fogData.fogMobs[i]).DestroyAllClones();
        }
    }

    public GameObject[] SpawnPointsInit()
    {
        GameObject[] spawners = new GameObject[fogData.spawnPointsCount];
        float SpawnDistance = fogData.fog.shape.radius + fogData.fog.shape.donutRadius * 2;
        Vector3 spawnpos = new Vector3(0, 2, 0);
        
        for (int i = 0; i < spawners.Length; i++)
        {
            spawnpos.x = Mathf.Cos(2 * Mathf.PI / spawners.Length * i) * SpawnDistance;
            spawnpos.z = Mathf.Sin(2 * Mathf.PI / spawners.Length * i) * SpawnDistance;
            spawners[i] = NightPool.Spawn(fogData.spawnerPrefab, spawnpos + fogData.transform.position, quaternion.identity, fogData.transform);
        }
        return spawners;
    }


}