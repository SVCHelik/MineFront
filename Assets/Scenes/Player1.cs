using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{ 
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;

    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;

    private void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    private void Update()
    {
        Run(Input.GetKey(KeyCode.LeftShift));
        float x = Input.GetAxis("horizontal2");
        float z = Input.GetAxis("vertical2");
        _walkDirection = transform.right * x + transform.forward * z;
    }

    private void FixedUpdate()
    {
        Walk(_walkDirection);
    }

    private void Walk(Vector3 direction)
    {
        _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
    }





    private void Run(bool canRun)
    {
        _speedWalk = canRun ? _speedRun : _speed;
    }

}
