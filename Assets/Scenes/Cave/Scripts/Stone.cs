using UnityEngine;
using NTC.Pool;
using Unity.Mathematics;
public class Stone : MonoBehaviour, IDespawnable, ISpawnable
{
    public float HP = 100;
    public float MaxHP = 100;
    public int expGain = 0;
    public GameObject expPref;
    public Renderer placeEffectRenderer;
    public float distance;
    public Color[] colors = new Color[] {
        Color.gray,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.red,
        Color.magenta,
        Color.cyan,
    };  

    private void Update() 
    {
        
    }

    
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
    public void SetColor(float distance){
        
        Color color1 = colors[(int)(distance*6)];
        Color color2 = colors[(int)(distance*6)+1];
        placeEffectRenderer.material.color = Color.Lerp(color1, color2, distance - (int)distance);
    }

    public void OnSpawn()
    {
        //SetColor(distance);
    }
}