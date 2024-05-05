using Pixelplacement;
using UnityEngine;
using NTC.Pool;
public class DroneAttackState : State {
    public DroneFSM dronefsm;
    public float speed = 20;
    public float Distance;
    public Vector3 wayPoint;
    public TrailRenderer trailRenderer;
    float bombfriq = 0.1f;
    public GameObject bombPref;
    private float timer;


    private void OnEnable() {
        transform.position = dronefsm.lastposition;
        wayPoint = dronefsm.lastDirection*Distance + transform.position;
        transform.LookAt(wayPoint);
        trailRenderer.enabled = true;
    }

    private void FixedUpdate() {
        timer += Time.fixedDeltaTime;
        Move();
    }

    private void Move(){
        if(timer> bombfriq){
            timer = 0;
            NightPool.Spawn(bombPref, transform.position, Quaternion.identity);
        }
        if(Vector3.Distance(transform.position, wayPoint)>0.1)
            transform.position = Vector3.MoveTowards(transform.position, wayPoint, speed * Time.fixedDeltaTime);
        else ChangeState(nameof(DroneIdleState));
    }
    
    private void OnDisable() {
        transform.position = dronefsm.lastposition;
        trailRenderer.Clear();
        trailRenderer.enabled = false;
    }
}