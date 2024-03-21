using UnityEngine;
using NTC.MonoCache;
using System.Threading;

public class CubeSpawn: MonoCache {
    [Tooltip("ширина и длина")]
    public int width;
    public int height;
    [Tooltip("объекты которые будут спавниться")]
    public GameObject pref1;
    public GameObject pref2;
    [Tooltip("это надо для некоторых перлинов")]
    public float modifier;
    public GameObject[,] objects;
    public int[,] map;

    Transform Player;
    private float timer = 0;
    Vector3 pos;
    void Start(){   
        pos = Player.position;

        float seed = System.DateTime.Now.Millisecond;
        //это просто надо
        map = MapFunctions.GenerateArray(width, height, false);
        //тут функция генерирующая карту, берем из MapFunctions
        map = MapFunctions.RandomWalkCave(map,seed,  (int)modifier);
        //тут рендер он из ExpGenScripts потому что в ориге сделано через tilemap
        objects = ExpGenScripts.RenderMap(map,10, pref1, pref2);
    }
    protected override void Run(){
        
    }
}
