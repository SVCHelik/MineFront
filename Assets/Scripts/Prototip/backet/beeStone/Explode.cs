using UnityEngine;

public class Explode : MonoBehaviour
{
    public float radius = 40f;
    public float force = 50f;
    public float mode = 3f;
    private void Start()
    {
    }
    public void OnEnable() {
        EventBus.ExplodeAsked += explode; 
    }
    public void OnDisable(){
    EventBus.ExplodeAsked -= explode;    
    }
    void explode(float force, float radius, float mode)
    {
        EventBus.Exploded?.Invoke(force, transform.position, radius, mode);
        Destroy(gameObject);
    }
}