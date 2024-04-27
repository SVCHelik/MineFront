using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(SpawnController))]
public class FogFSM : MonoBehaviour
{

    public GameObject[] players;
    public CinemachineVirtualCamera cam;
    public CinemachineTransposer transposer;
    public float playersDist;
    public float maxDist = 100;
    public ParticleSystem fog;

    public float MaxCount = 500f;
    public float MinCount = 0f;
    public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public AnimationCurve spawnCurve;
    public float FogChangingDuration = 1;
    public SpawnController spawnController;
    public float SpawnSpeed;
    public int spawnPointsCount;
    public int spawnAmount;
    public GameObject spawnerPrefab;
    public GameObject[] fogMobs;
 

    private void Start()
    {
        spawnController = GetComponent<SpawnController>();
        cam.GetCinemachineComponent<CinemachineTransposer>();
        fog = GetComponent<ParticleSystem>();

    }
    

}