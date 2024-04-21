using UnityEngine;

public class BatEnemy : Enemy{
    public  float attackDistance;
    public float DistanceOffset;
    float timer;
    public void FixedUpdate() {
        FindTarget();
        transform.LookAt(target);
    }

    public void Update() {


    }
    public override void PerformAttack() {
        //тут скрипт атаки      
    }
   

}