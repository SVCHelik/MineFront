using UnityEngine;


public class OnDistanceFog : MonoBehaviour {
    public GameObject[] players;
    public float playersDist;
    public float maxDist = 100;
    ParticleSystem.MainModule fog;
    public float maxSize = 40;
    public float minSize = 0;
    
    void Start(){
        players = GameObject.FindGameObjectsWithTag("Player"); 
        fog = GetComponent<ParticleSystem>().main;
        
    }   

    void Update(){
        playersDist = Vector3.Distance(players[0].transform.position, players[1].transform.position);
        if(players.Length == 2){
            if ( playersDist >= 20 && playersDist <= maxDist){
                fog.startSize = playersDist - 20;
            }
            else fog.startSize = 0;
        }
    }
    
    
}