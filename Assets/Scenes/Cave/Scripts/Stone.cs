using UnityEngine;
using NTC.Pool;

public class Stone : MonoBehaviour, IDespawnable, ISpawnable
{
    public long HP = 128;
    public int startHP = 128;
    public long MaxHP = 128;
    public int oreGain = 0;
    public int radius = 5;
    public GameObject orePref;
    public Renderer placeRenderer;
    public Renderer rockRenderer;
    public  ParticleSystem particleSystem;
    public bool flag;
    
    [Range(0,0.99f)]public float distance;
    
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
        if(flag)SetColor(distance);
    }

    
    public void ApplyDamage(float damage)
    {
        if(HP > damage){
            HP -= (int)damage;
            particleSystem.Play();
            SpawnOre();
            rockRenderer.material.color = Color.Lerp(placeRenderer.material.color, Color.gray, HP/MaxHP);
        }
        else{
            HP = 0;
            for (int i = 0; i<=30;i++){
                SpawnOre();
            }    
            NightPool.Despawn(gameObject);
        }
    }

    public void OnDespawn()
    {
       
    }
  
    void SpawnOre(){
        Vector3  randomPos = Random.insideUnitSphere*radius + transform.position;
        randomPos.y = 1;
        GameObject ore = NightPool.Spawn(orePref,randomPos, Quaternion.FromToRotation(randomPos, Random.insideUnitSphere)); 
        ore.GetComponent<OrePart>().value = (int)MaxHP/10;
        ore.GetComponent<Renderer>().material.color = placeRenderer.material.color;
    }
    public void SetColor(float distance){
        Color color1 = colors[(int)(distance*6)];
        Color color2 = colors[(int)(distance*6)+1];   
        HP = startHP* (int)Mathf.Pow(2,(int)(distance*6));
        MaxHP = HP;
        placeRenderer.material.color = Color.Lerp(color1, color2, distance - (int)distance);
        rockRenderer.material.color = Color.Lerp(color1, color2, distance - (int)distance);
    }

    public void OnSpawn()
    {
        //SetColor(distance);
    }
}