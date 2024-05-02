using UnityEngine;
public class pickableItem : MonoBehaviour {
    public Transform target;
     public int value;
    //[SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float TakeRadius;
    public float moveSpeed;
    public float orbitSpeed = 100f; // Скорость полета по кругу
    public bool isOnMove = false;

    public void RotateMove(){
        if(target){
            transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target);
        }
        
    }
}