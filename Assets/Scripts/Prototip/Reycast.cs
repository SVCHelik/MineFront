using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycast : MonoBehaviour
{

    public float timeSpawn = 2f;
    private float timer;
    private bool CanFier = false;
    float BulletSpeed = 10f;

    public GameObject target;
    private Enemy EnemyScript;
    public GameObject BulletPrefab;
    public Transform BulletShutPoint;
    public GameObject BulletObj;

    private void Start()
    {
        timer = timeSpawn;
    }

    void Update(){
        target = Functions.FindNearObject("Enemy", transform.position);
        
    // Update is called once per frame
    //сюда запишется инфо о пересечении луча, если оно будет
        RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    //Ray ray = new Ray(transform.position, target.transform.position - transform.position);
    //пускаем луч
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit);

        timer -= Time.deltaTime;
        
        //если луч с чем-то пересёкся, то..
        //если луч не попал в цель
        if (hit.collider != null){
            if (hit.collider.GetComponent<Collider>().name == target.GetComponent<Collider>().name) {
                //Debug.Log("Виден");
                CanFier = true;
                EnemyScript = target.GetComponent<Enemy>();
            }
            else {
                CanFier = false;
                Debug.Log("Путь к врагу преграждает объект: "+hit.collider.name);
            }
            Debug.DrawLine(ray.origin, hit.point,Color.red);
            if (timer <= 0)
            {
                if (CanFier){
                    timer = timeSpawn;
                    EnemyScript.Hit();
                    //BulletObj = Instantiate(BulletPrefab, (BulletShutPoint.position + target.transform.position)/2, transform.rotation);
                    //BulletObj.transform.localScale = new Vector3(0.2f, 0.2f, Vector3.Distance(BulletShutPoint.position, target.transform.position));
                    //BulletObj.GetComponent<Bullet>().Target = target.transform.position;
                    BulletObj = Instantiate(BulletPrefab, BulletShutPoint.position, transform.rotation);
                    BulletObj.GetComponent<Bullet>().LiveTime = Vector3.Distance(BulletShutPoint.position, target.transform.position)/BulletSpeed/10;
                }
                
                
            }
        }
        }
}
