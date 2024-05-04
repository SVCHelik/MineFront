using Pixelplacement;
using UnityEngine;

public class DroneFSM : StateMachine    {
    public Transform target;
    public float speed = 0;
    public bool OnAttack = false;
    public float idleRadius = 20;
    public Vector3 lastDirection;
    public Vector3 lastposition;
    
}