using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeExplode : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float radius;
    [SerializeField] private float mode;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        EventBus.ExplodeAsked.Invoke(force, radius, mode);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
