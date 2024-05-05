using Pixelplacement;
using UnityEngine;

public class BatAttackState : State {
    public BatEnemy batEnemy;
    private void OnEnable() {
        
    }
    private void FixedUpdate() {
        
    }
    private void Update() {
        if(Vector3.Distance(transform.position, batEnemy.target.position) + batEnemy.DistanceOffset >= batEnemy.attackDistance){
            ChangeState("BatFollowState");
        }
        //тут применение атаки
    }
    
    private void OnDisable() {
        
    }
}