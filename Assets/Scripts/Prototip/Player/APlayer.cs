using UnityEngine;
using NTC.OverlapSugar;
using UnityEngine.InputSystem;

public abstract class APlayer : MonoBehaviour
{ 
    public int expCount;
    public int level;
    public int oreCount;
    public int currentHP;
    public int maxHP;
    public float _speedWalk;
    
    public float speedMine = 0.1f;
    public float damageMine;

    public OverlapSettings overlapMine;
    public OverlapSettings overlapAttack;
    protected Vector3 fixDir;
    protected CharacterController _characterController;

    protected bool mining;
    protected float timer;

    public void Walk()
    {
        
        _characterController.Move(fixDir * _speedWalk * Time.fixedDeltaTime);

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputVec = context.ReadValue<Vector2>();
        fixDir = transform.InverseTransformDirection(new Vector3(inputVec.x, 0, inputVec.y));
    }
    public void OnMine(InputAction.CallbackContext context){
        if(context.started){
            mining = true;
            timer = 0;
        }
        if(context.canceled){
            mining = false;
            timer  = 0;
        }
        
    }
    public void CastStoneMine(){
        if(overlapMine.TryFind(out Stone stone)){
            stone.ApplyDamage(damageMine);
        }
    }
    public void ApplyExp(int exp){
        expCount += exp;
    }
    public void ApplyOre(int ore){
        oreCount += ore;
    }
    
}
