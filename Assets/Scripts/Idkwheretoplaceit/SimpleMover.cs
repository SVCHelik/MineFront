using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
{
    GetComponent<Rigidbody>().AddForce(transform.forward * _speed, ForceMode.VelocityChange);
}
    public void setSpeed(float speed){
        _speed = speed;
    }
    public void addSpeed(float speed){
        _speed += speed;
    }
    
}
