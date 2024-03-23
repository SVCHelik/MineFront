using UnityEngine;
using NTC.Pool;
public class Enemy : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject[] players;
    public float moveSpeed = 5f;
    private CharacterController EnemyController;
    private Vector2 movement;
    

    // Start is called before the first frame update
    void Start(){
    EnemyController = GetComponent<CharacterController>();
    players = GameObject.FindGameObjectsWithTag("Player");
    player1 = players[0];
    player2 = players[1];
    }
//
    // Update is called once per frame
    void Update(){
        Vector3 direction1 = player1.transform.position - transform.position;
        Vector3 direction2 = player2.transform.position - transform.position;
        //Debug.Log(angle);
        //Debug.Log(direction);
        if (Functions.FindNearObject("Player", transform.position)){
            transform.LookAt(Functions.FindNearObject("Player", transform.position).transform);
        }
    }
    private void FixedUpdate() {
        EnemyController.Move(transform.forward * moveSpeed * Time.deltaTime);
    }
    public void Hit(){
        Debug.Log("умер");
        NightPool.Despawn(transform.gameObject);
    }
}