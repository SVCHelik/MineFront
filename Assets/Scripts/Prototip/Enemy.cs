using UnityEngine;
using NTC.Pool;

public class Enemy : MonoBehaviour, IPoolable, IDamageable
{
    public GameObject[] players;
    public Transform target;
    public float moveSpeed = 5f;
    //private Vector2 movement;
    public float HP = 100;
    public float maxHP = 100;
    public Rigidbody rigidBody;

    public void OnDespawn()
    {
        // rigidBody.velocity = Vector3.zero;
        // rigidBody.angularVelocity = Vector3.zero;
        EventBus.MobDespawned?.Invoke(maxHP);
    }

    public void OnSpawn()
    {
        HP = maxHP;
        EventBus.MobSpawned?.Invoke(HP);
    }
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Player"); 
    }

    void Update()
    {
        transform.LookAt(target);
        if(players.Length == 2)
            if ((transform.position - players[0].transform.position).magnitude <= (transform.position - players[1].transform.position).magnitude)
                target = players[0].transform;
            else
                target = players[1].transform;
        else if(players[0])
            target = players[0].transform;
        
        
    }
    private void FixedUpdate() 
     {
        if (Vector3.Distance(transform.position, target.position) > 50)
            NightPool.Despawn(gameObject);
        if (target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        
    }


    public void ApplyDamage(float damage)
    {
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
            TakeHit();
        }
    }
}