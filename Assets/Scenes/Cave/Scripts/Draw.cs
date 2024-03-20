using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Draw : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("ширина и длина")]
    public int width;
    public int height;
    [Tooltip("объекты которые будут спавниться")]
    public GameObject pref1;
    public GameObject pref2;
    [Tooltip("это надо для некоторых перлинов")]
    public float modifier;
    void Start()
    {
        float seed = System.DateTime.Now.Millisecond;
        int[,] map;
        //это просто надо
        map = MapFunctions.GenerateArray(width, height, false);
        //тут функция генерирующая карту, берем из MapFunctions
        map = MapFunctions.RandomWalkCave(map,seed,  (int)modifier);
        //тут рендер он из ExpGenScripts потому что в ориге сделано через tilemap
        ExpGenScripts.RenderMap(map, pref1, pref2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
