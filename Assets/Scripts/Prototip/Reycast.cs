using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycast : MonoBehaviour
{

    public float timeSpawn = 2f;
    private float timer;
    private bool CanFier = false;
    public float BulletSpeed = 100f;
    public int NumerOfGun = 0;

    public GameObject target;
    private Enemy EnemyScript;
    public GameObject BulletPrefab;
    public GameObject ShutPrefab;
    public Transform BulletShutPoint;
    public GameObject BulletObj;
    int Trigger_layer_mask = 1 << 9;
    public GameObject ShutObj;

    private void Start()
    {
        timer = timeSpawn;
        Trigger_layer_mask = ~Trigger_layer_mask;
        Debug.Log(Trigger_layer_mask);
    }

    void Update(){
        target = Functions.FindNearObject("Enemy", transform.position);
        
        timer -= Time.deltaTime;
        if (NumerOfGun == 0) AutomaticShot();
        //
        else if (NumerOfGun == 1) ShutGunShot();


        
        }
    public void AutomaticShot()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, Mathf.Infinity, Trigger_layer_mask);
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
                    EnemyScript.TakeHit();
                    BulletObj = Instantiate(BulletPrefab, BulletShutPoint.position, transform.rotation);
                    BulletObj.GetComponent<Bullet>().LiveTime = Vector3.Distance(BulletShutPoint.position, target.transform.position)/BulletSpeed;
                    BulletObj.GetComponent<Bullet>().BulletSpeed = BulletSpeed;
                }
                
                
            }
        }
    }
    public void ShutGunShot()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, Mathf.Infinity, Trigger_layer_mask);
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
            if (timer <= 0)
            {
                if (CanFier){
                    timer = timeSpawn;
                    ShutObj = Instantiate(ShutPrefab, BulletShutPoint.position, transform.rotation);
                    ShutObj.GetComponent<Trigger>().FullDamage = 20;
                    ShutObj.GetComponent<Trigger>().LiveTime = 2;

                }
                
                
            }
        }
    }

}
