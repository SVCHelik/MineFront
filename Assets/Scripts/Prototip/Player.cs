
using UnityEngine;
using NTC.MonoCache;

public class Player : MonoCache
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
    }
    // Update is called once per frame
    protected override void Run()
    {
        PlayerRun(Input.GetKey(KeyCode.LeftShift));
        float x;
        float z;
        if (player_nomber == 1){
            x = Input.GetAxis("horizontal1");
            z = Input.GetAxis("vertical1");
            _CamF.Player1_x = transform.position.x;
            _CamF.Player1_z = transform.position.z;
        }
        else {
            x = Input.GetAxis("horizontal2");
            z = Input.GetAxis("vertical2");
            _CamF.Player2_x = transform.position.x;
            _CamF.Player2_z = transform.position.z;
        }
        _walkDirection = transform.right * x + transform.forward * z;
        _walkDirection.Normalize();

        if (Functions.FindNearObject("Enemy", transform.position)){
            transform.LookAt(Functions.FindNearObject("Enemy", transform.position).transform);
        }
    

    }
 
    protected override void FixedRun()
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
