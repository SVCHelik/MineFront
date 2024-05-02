using UnityEngine;
using NTC.Pool;

public class Enemy : MonoBehaviour, IPoolable, IDamageable
{   
    public Transform target;
    public float moveSpeed = 5f;
    //private Vector2 movement;
    public float HP = 100;
    public float maxHP = 100;
    public GameObject expPref;

    public void OnDespawn()
    {
        EventBus.MobDespawned?.Invoke(maxHP);
    }

    public void OnSpawn()
    {
        HP = maxHP;
        EventBus.MobSpawned?.Invoke(HP);
    }
    void Start(){
        target = transform;
    }

    void Update()
    {
        FindTarget();   
        transform.LookAt(target);
    }
    private void FixedUpdate() 
    {
        Move();
    }
    public virtual void Move(){
        if (Vector3.Distance(transform.position, target.position) > 50)
            NightPool.Despawn(gameObject);
        if (target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);

    }
    public void FindTarget(){
        if(PlayerObserver.Is1PlayerAlive && PlayerObserver.Is2PlayerAlive)
            if (Vector3.Distance(transform.position, PlayerObserver.Player1Pos.transform.position) <= Vector3.Distance(transform.position, PlayerObserver.Player2Pos.transform.position))
                target = PlayerObserver.Player1Pos;
            else
                target = PlayerObserver.Player2Pos;
        else if(PlayerObserver.Is1PlayerAlive) target = PlayerObserver.Player1Pos;
        else if(PlayerObserver.Is2PlayerAlive) target = PlayerObserver.Player2Pos;
        else NightPool.Despawn(gameObject);
     
    }


    public void spawnExp(){
        GameObject tmp  = NightPool.Spawn(expPref, transform.position, Quaternion.identity);
        tmp.GetComponent<ExpPart>().value = (int)maxHP;
    }
    public virtual void PerformAttack(){
        
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log(HP);
        if(HP >= damage){
            HP -= damage;
        }
        else Die();
    }
    public void Die(){
        spawnExp();
        NightPool.Despawn(gameObject);

        
    }

}