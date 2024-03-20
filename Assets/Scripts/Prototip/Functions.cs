using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public GameObject FindNearObject(string Tag, Vector3 Position) // Функция аналогичная Player
    {
        GameObject[] All_Enemy = new GameObject[GameObject.FindGameObjectsWithTag(Tag).Length];
        GameObject Near_Enemy = new GameObject();
        All_Enemy = GameObject.FindGameObjectsWithTag(Tag);
        Near_Enemy = null;
        foreach (GameObject One_Enemy in All_Enemy)
        {
            if (!Near_Enemy) Near_Enemy = One_Enemy;
            if ((Near_Enemy.transform.position - Position).sqrMagnitude > (One_Enemy.transform.position - Position).sqrMagnitude){
                Near_Enemy = One_Enemy;
            }
        }
        return (Near_Enemy);
    }
}
