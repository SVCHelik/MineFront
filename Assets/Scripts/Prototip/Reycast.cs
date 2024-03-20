using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycast : MonoBehaviour
{
    [SerializeField] private Functions Functions;

    private GameObject target;
    void Update(){
    target = Functions.FindNearObject("Player", transform.position);
    // Update is called once per frame
    //сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(transform.position, target.transform.position - transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);

    //если луч с чем-то пересёкся, то..
       //если луч не попал в цель
        Debug.Log("Путь к врагу преграждает объект: "+hit.collider.name);
 
        Debug.DrawLine(ray.origin, hit.point,Color.red);
    
    }
}
