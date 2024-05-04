using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NTC.OverlapSugar;
using UnityEngine;


public class Functions: MonoBehaviour
{
    public static bool TryFindNearEnemy(Vector3 Position, out GameObject nearest, float range = 30) // Функция аналогичная Player
    {
        Collider nearEnemy = null;
        Collider[] allEnemy = Physics.OverlapSphere(Position, range,1<<7);
        float minDistance = 1000;
        float tempDistance;
        nearest = null;
        if(allEnemy.Length == 0) return false;
        foreach (Collider enemy in allEnemy)
        {
            tempDistance = Vector3.Distance(enemy.transform.position, Position);
            if (!nearEnemy){
                nearEnemy = enemy;
                minDistance = Vector3.Distance(nearEnemy.transform.position, Position);
            }
            else if (minDistance > tempDistance){
                nearEnemy = enemy;
                minDistance = tempDistance;
            }
        }
        nearest = nearEnemy.gameObject;
        return true;
    }
}
