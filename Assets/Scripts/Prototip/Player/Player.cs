
using UnityEngine;

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
    public int exp;
    public int lvl;
    public int currentHP;
    public int maxHP;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] public float player_nomber;
    public CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    public CamField_moove _CamF;

    public bool canMine;
    public float speedMine;
    public float damageMine;
    Stone stone;
    float timer = 0;


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
                if(timer > speedMine && canMine) {
                    stone?.ApplyDamage(damageMine);    
                    timer = 0;
                }
            }
        }
        else {
            x = Input.GetAxis("horizontal2");
            z = Input.GetAxis("vertical2");
            if(Input.GetKeyDown("2")){
                if(timer > speedMine && canMine) {
                    stone?.ApplyDamage(damageMine); 
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
    
    void ExpAttack(Collider[] colliders){
        foreach (var collider in colliders)
        {
            collider.GetComponent<ExpPart>().PerformAttack();
        }
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
    public void ApplyExp(int exp){
        this.exp += exp;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stone"){
            canMine = true;
            stone = other.gameObject.GetComponent<Stone>();
        }        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stone"){
            canMine = false;
            stone = null;
        }        
    }
    
}
