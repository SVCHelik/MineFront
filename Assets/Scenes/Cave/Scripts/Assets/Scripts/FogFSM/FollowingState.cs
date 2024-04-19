using UnityEngine;

using Pixelplacement;

public class FollowingState : State
{   
    float timer;
    public ParticleSystem.MainModule fogMain;
    public FogFSM fogData;
    

    private void OnEnable()
    {
        Debug.Log("Following");
        timer = 0;
    }

    
    public void Update()
    {
        if (PlayerObserver.getPlayersDist()> fogData.maxDist)
        {
            ChangeState("SpawnState");
        }
        timer += Time.deltaTime;
        if(fogMain.maxParticles != 0){
            fogMain.maxParticles = (int)(fogData.hideCurve.Evaluate(timer) * fogData.MaxCount);
        }
    }

    private void OnDisable() {
        
    }
}