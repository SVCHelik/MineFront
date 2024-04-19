
using UnityEngine;

public static class PlayerObserver{
    public static Transform Player1Pos;
    public static Transform Player2Pos;
    public static float getPlayersDist(){
        return Vector3.Distance(Player1Pos.position, Player2Pos.position);
    }

}

public class Player : MonoBehaviour
{ 
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float player_nomber;
    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    public CamField_moove _CamF;

    void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
        if (player_nomber == 1){
            PlayerObserver.Player1Pos = transform;
        }
        else {
            PlayerObserver.Player2Pos = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        PlayerRun(Input.GetKey(KeyCode.LeftShift));
        float x;
        float z;
        if (player_nomber == 1){
            x = Input.GetAxis("horizontal1");
            z = Input.GetAxis("vertical1");
        }
        else {
            x = Input.GetAxis("horizontal2");
            z = Input.GetAxis("vertical2");
        }
        _walkDirection = transform.right * x + transform.forward * z;
        _walkDirection.Normalize();

        if (Functions.FindNearObject("Enemy", transform.position)){
            transform.LookAt(Functions.FindNearObject("Enemy", transform.position).transform);
        }
    

    }
 
    void FixedUpdate()
    {
        Walk(_walkDirection);
    }

    private void Walk(Vector3 direction)
    {
        
        //Vector3 direction_fix = new Vector3 (direction.x * transform.forward + direction.z * transform.forward)
        Vector3 fixdir = transform.InverseTransformDirection(direction);
        _characterController.Move(fixdir * _speedWalk * Time.fixedDeltaTime);
    }


    private void PlayerRun(bool canRun)
    {
        _speedWalk = canRun ? _speedRun : _speed;
    }

}
