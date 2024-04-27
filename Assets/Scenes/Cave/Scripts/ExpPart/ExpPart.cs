using UnityEngine;
using NTC.Pool;
using Unity.VisualScripting;

public class ExpPart : Enemy {
    [SerializeField] public int expValue;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float TakeRadius;


    public float orbitSpeed = 100f; // Скорость полета по кругу
    public float minDistance = 0; // Минимальное расстояние до центрального объекта
    public float maxDistance = 0; // Максимальное расстояние до центрального объекта
    public float orbitRadius = 0;

    private float currentAngle; // Текущий угол орбиты
    private void OnEnable() {
        FindTarget();
        currentAngle = Random.Range(0f, 360f);
        orbitRadius = Vector3.Distance(transform.position, target.position);
    }
    private void Start() {
        target = transform;    
    }

    private void Update() {
        FindTarget();
        //transform.LookAt(target);
        if (Vector3.Distance(transform.position, target.position)<=TakeRadius)Move();
    }
    public override void Move(){
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        transform.LookAt(target);
    }

    private void OnDisable() {
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {            
            if (other.gameObject.TryGetComponent(out Player player)){
                player.ApplyExp(expValue);
                _explosion.Play();
                NightPool.Despawn(gameObject);
            }

        }
    }
    

}