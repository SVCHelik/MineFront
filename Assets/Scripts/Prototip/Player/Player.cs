
using UnityEngine;
using NTC.OverlapSugar;
using System;
public static class PlayerObserver{
    public static Transform Player1Pos;
    public static Transform Player2Pos;
    public static float getPlayersDist(){
        return Vector3.Distance(Player1Pos.position, Player2Pos.position);
    }
    public static bool Is1PlayerAlive;
    public static bool Is2PlayerAlive;

}

public class Player : MonoBehaviour
{ 
    public int expValue;
    public int level;
    public int oreValue;
    public int currentHP;
    public int maxHP;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] public float player_nomber;
    public CharacterController _characterController;
    private Vector3 _walkDirection;
    
    private float _speed;
    public float speedMine;
    public float damageMine;
    float timer = 0;


    [SerializeField] OverlapSettings overlapStone;


    void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
        if (player_nomber == 1){
            PlayerObserver.Player1Pos = transform;
            PlayerObserver.Is1PlayerAlive = true;
        }
        else {
            PlayerObserver.Player2Pos = transform;
            PlayerObserver.Is2PlayerAlive = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        PlayerRun(Input.GetKey(KeyCode.LeftShift));
        float x;
        float z;
        if (player_nomber == 1){
            x = Input.GetAxis("horizontal1");
            z = Input.GetAxis("vertical1");
            if(Input.GetKeyDown("1")){
                if(timer > speedMine) {
                    CastStoneMine();
                    timer = 0;
                }
            }
        }
        else {
            x = Input.GetAxis("horizontal2");
            z = Input.GetAxis("vertical2");
            if(Input.GetKeyDown("2")){
                if(timer > speedMine) {
                    CastStoneMine();
                    timer = 0;
                }  
            }
        }
        _walkDirection = transform.right * x + transform.forward * z;
        _walkDirection.Normalize();
        if (Functions.FindNearObject("Enemy", transform.position)){
            transform.LookAt(Functions.FindNearObject("Enemy", transform.position).transform);
        }

    }
    private void FixedUpdate()
    {
        Walk();
    }
    
  

    public void Walk()
    {
        
        //Vector3 direction_fix = new Vector3 (direction.x * transform.forward + direction.z * transform.forward)
        Vector3 fixdir = transform.InverseTransformDirection(_walkDirection);
        _characterController.Move(fixdir * _speedWalk * Time.fixedDeltaTime);

    }

    private void PlayerRun(bool canRun)
    {
        _speedWalk = canRun ? _speedRun : _speed;
    }
    private void CastStoneMine(){
        if(overlapStone.TryFind(out Stone stone)){
            stone.ApplyDamage(damageMine);
        }
    }
    public void ApplyExp(int exp){
        expValue += exp;
    }
    public void ApplyOre(int ore){
        oreValue += ore;
    }
    
    
    #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            overlapStone.TryDrawGizmos();
        }
    #endif
}
