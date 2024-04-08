using UnityEngine;
using NTC.Pool;
public class EnemyNav : MonoBehaviour
{
    public GameObject[] players;
    public Transform target;
    public float moveSpeed = 5f;
    private Vector2 movement;
    public float Xp = 100;
    

    void Start(){
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update(){
        // Vector3 direction1 = player1.transform.position - transform.position;
        // Vector3 direction2 = player2.transform.position - transform.position;
        //Debug.Log(angle);
        //Debug.Log(direction);
        
        if(players.Length == 2)
            if ((transform.position - players[0].transform.position).magnitude <= (transform.position - players[1].transform.position).magnitude)
                target = players[0].transform;
            else
                target = players[1].transform;
        else if(players[0])
            target = players[0].transform;
        
        transform.LookAt(target);
        // if (Xp<=0){
        //     Destroy(transform.gameObject);
        // }
        //if (transform.position.y < 1f || transform.position.y > 1.1f) transform.position = new Vector3(transform.position.x, 1.01f, transform.position.z);// не дает проваливаться под землю, но приколы при контакте
    }
    private void FixedUpdate() {
        if ((transform.position - target.position).magnitude > 50)
            NightPool.Despawn(gameObject);
        if (target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        
    }
    // public void Hit(){
    //     Debug.Log(Xp);
    //     Xp -=10;
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NightPool.Despawn(gameObject);
        }
    }
}