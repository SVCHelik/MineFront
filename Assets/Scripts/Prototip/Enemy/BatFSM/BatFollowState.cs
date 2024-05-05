using UnityEngine;
using Pixelplacement;

public class BatFollowState : State {
    public BatEnemy batEnemy;   

    private void OnEnable() {
        
    }
    private void OnDisable() {
        
    }
    private void FixedUpdate() {
        batEnemy.Move();
        if(Vector3.Distance(transform.position, batEnemy.target.position) <= batEnemy.attackDistance){
            ChangeState("BatAttackState");
        }
    }
}