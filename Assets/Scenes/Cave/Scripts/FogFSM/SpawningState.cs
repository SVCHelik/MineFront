using UnityEngine;
using NTC.Pool;
using Unity.Mathematics;
using Pixelplacement;

public class SpawningState : State
{
    [SerializeField] private SpawnController spawnController;
    public FogFSM fogData;
    public ParticleSystem.MainModule fogMain;

    float timer;
    private void Start() {
        fogMain = fogData.fog.main;
        fogData.spawnController.mobs = fogData.fogMobs;
    }

    private void OnEnable() {
        
        //fogFsm.transposer.enabled = false; 
        SpawnPointsInit();
        fogData.spawnController.enabled = true;
        fogData.fog.Play();
        timer = 0;
    }

    private void Update()
    {

        // Check conditions for transitioning to other states
        if (PlayerObserver.getPlayersDist() < fogData.maxDist)
        {
            ChangeState("FollowState");
        }

        timer += Time.deltaTime;
        if(timer <= fogData.FogChangingDuration){
            fogData.spawnController.spawnSpeed = fogData.spawnCurve.Evaluate(timer);
            fogMain.maxParticles = (int)(fogData.showCurve.Evaluate(timer) * fogData.MaxCount);
        }
        
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        NightPool.GetPoolByPrefab(fogData.spawnerPrefab).DespawnAllClones();
        for (int i = 0; i< fogData.fogMobs.Length; i++){
            NightPool.GetPoolByPrefab(fogData.fogMobs[i]).DespawnAllClones();
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