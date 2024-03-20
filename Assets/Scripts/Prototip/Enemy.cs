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
        FindNearObject("Player");
        
    }
    private void FixedUpdate() {
        EnemyController.Move(transform.forward * moveSpeed * Time.deltaTime);
    }


    private void FindNearObject(string Tag) // Функция аналогичная Player
    {
        GameObject[] All_Enemy = new GameObject[GameObject.FindGameObjectsWithTag(Tag).Length];
        GameObject Near_Enemy = new GameObject();
        All_Enemy = GameObject.FindGameObjectsWithTag(Tag);
        Near_Enemy = null;
        foreach (GameObject One_Enemy in All_Enemy)
        {
            if (!Near_Enemy) Near_Enemy = One_Enemy;
            if ((Near_Enemy.transform.position - transform.position).sqrMagnitude > (One_Enemy.transform.position - transform.position).sqrMagnitude){
                Near_Enemy = One_Enemy;
            }

        }
        if (Near_Enemy) transform.LookAt(Near_Enemy.transform);
       
    }

}