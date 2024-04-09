using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMove : MonoBehaviour
{
    public GameObject Hosain;
    private CharacterController _characterController;
    public int flymod = 0;
    private float _speedFly = 7;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flymod == 0)
        {
            if (Functions.FindNearObject("Enemy", transform.position))
            {
                transform.LookAt(Functions.FindNearObject("Enemy", transform.position).transform);
            }
        if ((Hosain.transform.position - transform.position).magnitude > 10) flymod = 1;
        }
        else
        {
            if ((Hosain.transform.position - transform.position).magnitude < 2) flymod = 0;
            transform.LookAt(Hosain.transform);
            _characterController.Move(transform.forward * _speedFly * Time.fixedDeltaTime);
        }
    }
}
