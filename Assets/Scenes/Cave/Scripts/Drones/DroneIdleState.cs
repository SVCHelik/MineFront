using Pixelplacement;
using UnityEngine;

public class DroneIdleState : State {
    public DroneFSM dronefsm;
    private Transform target;
    private float speed = 3;
    private float idleRadius = 20;
    private Vector3 wayPoint = Vector3.zero;
    
    private void OnEnable() {
        transform.position = NewWayPoint();
    }
    private void Update() {
    } 
    private void FixedUpdate() {
        move();  
    }
    private void Start() {
        target = dronefsm.target;
        speed = dronefsm.speed;
        idleRadius = dronefsm.idleRadius;
    }
    private void move(){
        if (Vector3.Distance(target.position, transform.position) > 20){
            transform.position = NewWayPoint();
            wayPoint = NewWayPoint();
        }
        else{
            if(Vector3.Distance(wayPoint, transform.position)>0.1)
                transform.position = Vector3.MoveTowards(transform.position, wayPoint, speed * Time.fixedDeltaTime);
                
            else{    
                wayPoint = NewWayPoint();
                transform.LookAt(wayPoint);
            }
        }
    }
    private Vector3 NewWayPoint(){
        Vector3 newPos = Random.insideUnitSphere*idleRadius + target.transform.position;
        newPos.y = 4;
       
        return newPos;
    }
    private void OnDisable() {
        dronefsm.lastposition = transform.position;
        dronefsm.lastDirection = (wayPoint - transform.position).normalized;
    }

}