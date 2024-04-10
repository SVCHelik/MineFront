using UnityEngine;
using NTC.Pool;
using NTC.MonoCache;
public class Enemy : MonoCache, IPoolable
{
    public GameObject[] players;
    public Transform target;
    public float moveSpeed = 5f;
    //private Vector2 movement;
    public float HP = 100;

    public void OnDespawn()
    {
        
    }

    public void OnSpawn()
    {
        HP = 100;
    }
    void Start(){
    //EnemyController = GetComponent<CharacterController>();
    players = GameObject.FindGameObjectsWithTag("Player"); 
    }

    protected override void Run()
    {

        if(players.Length == 2)
            if ((transform.position - players[0].transform.position).magnitude <= (transform.position - players[1].transform.position).magnitude)
                target = players[0].transform;
            else
                target = players[1].transform;
        else if(players[0])
            target = players[0].transform;
        
        transform.LookAt(target);
        // if (HP<=0){
        //     Destroy(transform.gameObject);
        // }
        //if (transform.position.y < 1f || transform.position.y > 1.1f) transform.position = new Vector3(transform.position.x, 1.01f, transform.position.z);// не дает проваливаться под землю, но приколы при контакте
    }
    protected override void FixedRun() {
        if ((transform.position - target.position).magnitude > 50)
            NightPool.Despawn(gameObject);
        if (target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        
    }
    public void Hit(){
        Debug.Log(HP);
        if(HP >= 10){
            HP -=10;
        }
        else NightPool.Despawn(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DamageZone")
        {
            Hit();
        }
    }
}