using UnityEngine;
using NTC.Pool;
public class Stone : MonoBehaviour, IDespawnable
{
    public float HP = 100;
    public float MaxHP = 100;
    public int expGain = 0;
    public GameObject expPref;
    
    public void ApplyDamage(float damage)
    {
        if(HP >= damage){
            HP -= damage;
            SpawnExp();
        }
        else{
            HP = 0;
            NightPool.Despawn(gameObject);
        }
    }

    public void OnDespawn()
    {
        for (int i = 0; i<=10;i++){
            SpawnExp();
        }    
    }
    void SpawnExp(){
        expPref.GetComponent<ExpPart>().expValue = expGain;
        NightPool.Spawn(expPref,transform.position, Quaternion.identity, transform);
    }
}