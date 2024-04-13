using UnityEngine;
using NTC.Pool;
using NTC.MonoCache;
using NTC.OverlapSugar;
public class EnemyNav : MonoCache, IPoolable
{
    [SerializeField] private OverlapSettings _overlapSettings;
    public void OnDespawn()
    {
        EventBus.MobDespawned?.Invoke(HP);
    }

    public void OnSpawn()
    {
       EventBus.MobSpawned?.Invoke(HP);
    }

    public GameObject[] players;
    public Transform target;
    public float moveSpeed = 5f;
    private Vector2 movement;
    public int HP = 100;

    void Start(){
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
    // public void Hit(){
    //     Debug.Log(HP);
    //     HP -=10;
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NightPool.Despawn(gameObject);
        }
    }

}