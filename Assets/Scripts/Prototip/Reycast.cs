using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycast : MonoBehaviour
{

    public float timeSpawn = 2f;
    private float timer;
    private bool CanFier = false;

    public GameObject target;
    private Enemy EnemyScript;

    private void Start()
    {
        timer = timeSpawn;
    }

    void Update(){
        target = Functions.FindNearObject("Enemy", transform.position);
        EnemyScript = target.GetComponent<Enemy>();
    // Update is called once per frame
    //сюда запишется инфо о пересечении луча, если оно будет
        RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    //Ray ray = new Ray(transform.position, target.transform.position - transform.position);
    //пускаем луч
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (CanFier){
                timer = timeSpawn;
                EnemyScript.Hit();
            }
            
            
        }
        //если луч с чем-то пересёкся, то..
        //если луч не попал в цель
        if (hit.collider != null){
            if (hit.collider.GetComponent<Collider>().name == target.GetComponent<Collider>().name) {
                //Debug.Log("Виден");
                CanFier = true;
            }
            else {
                CanFier = false;
                Debug.Log("Путь к врагу преграждает объект: "+hit.collider.name);
            }
            Debug.DrawLine(ray.origin, hit.point,Color.red);
        }
        }
}
