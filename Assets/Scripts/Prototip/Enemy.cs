using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float moveSpeed = 5f;
    private CharacterController EnemyController;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start(){
        EnemyController = GetComponent<CharacterController>();
    }
//
    // Update is called once per frame
    void Update(){
        Vector3 direction1 = player1.transform.position - transform.position;
        Vector3 direction2 = player2.transform.position - transform.position;
        //Debug.Log(angle);
        //Debug.Log(direction);
        if (direction1.sqrMagnitude > direction2.sqrMagnitude) transform.LookAt(player2.transform);
        else transform.LookAt(player1.transform);
        
    }
    private void FixedUpdate() {
        EnemyController.Move(transform.forward * moveSpeed * Time.deltaTime);
    }

}