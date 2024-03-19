using System;
using UnityEngine;

public class BeeController : MonoBehaviour {
    [SerializeField]private GameObject _playerObject;
    [SerializeField]private GameObject stone;
    [SerializeField] private Rigidbody rig; 
    bool exploded = false;

    public Transform centerObject; // Объект, вокруг которого будет полет

    public float orbitSpeed = 100f; // Скорость полета по кругу
    public float minDistance = 2f; // Минимальное расстояние до центрального объекта
    public float maxDistance = 5f; // Максимальное расстояние до центрального объекта

    private float orbitRadius = 2; // Радиус орбиты
    private float currentAngle; // Текущий угол орбиты

    void Start() {
        // Получаем случайный радиус орбиты
        // Генерируем случайный угол орбиты
        currentAngle = UnityEngine.Random.Range(0f, 360f);
        if (_playerObject == null)
            _playerObject = GameObject.FindWithTag("Player");
        
        if (rig == null)
            rig  = GetComponent<Rigidbody>();
    }

    void Update() {
         // Увеличиваем угол для создания движения по орбите
        currentAngle += orbitSpeed * Time.deltaTime;

        // Преобразуем угол в радианы
        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        // Вычисляем новую позицию объекта по кругу
        Vector3 newPosition = centerObject.position + new Vector3(Mathf.Cos(angleInRadians), 0f, Mathf.Sin(angleInRadians)) * orbitRadius;

        // Применяем новую позицию
        transform.position = newPosition;

        // Направляем объект к центральному объекту (это необязательно, но может быть полезно для визуальной красоты)
        transform.LookAt(centerObject);

        // Проверяем расстояние до центрального объекта
        float distanceToCenter = Vector3.Distance(transform.position, centerObject.position);

        // Если расстояние меньше минимального, двигаемся от центра
        if (distanceToCenter < minDistance)
        {
            orbitRadius += 0.1f;
        }
        // Если расстояние больше максимального, двигаемся к центру
        else if (distanceToCenter > maxDistance)
        {
            orbitRadius -= 0.1f;
        }
    }


    public void explode(float force, Vector3 pos, float radius, float mode){
        rig.AddExplosionForce(force, pos, radius, mode);
        exploded = true;
    }
    
    private void OnEnable() {
        EventBus.Exploded += explode;
    }
    private void OnDisable(){
        EventBus.Exploded -= explode;
    }   
}