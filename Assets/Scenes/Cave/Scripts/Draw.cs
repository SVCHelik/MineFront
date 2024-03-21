using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.MonoCache;
using JetBrains.Annotations;
public class Draw: MonoCache 
{
    // Start is called before the first frame update
    [Tooltip("ширина и длина")]
    public int mapWidth;
    public int fieldWidth;
    [Tooltip("объекты которые будут спавниться")]
    public GameObject pref1;
    public GameObject pref2;
    [Tooltip("это надо для некоторых перлинов")]
    public float modifier;
    public GameObject[,] objects;
    int[,] map;
    float seed;
    void OnGUI()
    {
        
        if (GUILayout.Button("next"))
        {
            ExpGenScripts.RenderMapWithShift(map, objects, pref1, new Vector2Int(0, 10));
        }
        if (GUILayout.Button("re-generate"))
        {
            ReGen();
        }
    }
    void Start()
    {
        seed = System.DateTime.Now.Millisecond;
        //это просто надо
        map = MapFunctions.GenerateArray(mapWidth, mapWidth, false);
        //тут функция генерирующая карту, берем из MapFunctions
        map = MapFunctions.RandomWalkCave(map, seed,  (int)modifier);
        //тут рендер он из ExpGenScripts потому что в ориге сделано через tilemap
        objects = ExpGenScripts.RenderMap(map, fieldWidth, pref1, pref2);
        //ExpGenScripts.RenderMapWithShift(map, objects, pref1, new Vector2Int(10, 10));
    }
    void ReGen()
    {
        ExpGenScripts.despawn(objects);
        
        seed = System.DateTime.Now.Millisecond;
        //это просто надо
        map = MapFunctions.GenerateArray(mapWidth, mapWidth, false);
        //тут функция генерирующая карту, берем из MapFunctions
        map = MapFunctions.RandomWalkCave(map, seed,  (int)modifier);
        //тут рендер он из ExpGenScripts потому что в ориге сделано через tilemap
        objects = ExpGenScripts.RenderMap(map, fieldWidth, pref1, pref2);
        //ExpGenScripts.RenderMapWithShift(map, objects, pref1, new Vector2Int(10, 10));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
