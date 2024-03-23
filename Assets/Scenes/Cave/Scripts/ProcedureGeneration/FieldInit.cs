using UnityEngine;
using NTC.Pool;
public class FieldInit : MonoBehaviour {
    private GameObject[,] _objects; 
    [SerializeField] private int mapWidth;
    [SerializeField] private int fieldWidth;
    [SerializeField] private GameObject _prefab;
    
    void Start()
    {
        FieldChunkInit();
    }
    public GameObject[,] FieldChunkInit(){
        _objects = new GameObject[mapWidth, mapWidth];
        for(int x = 0; x < mapWidth; x+=fieldWidth){
            for(int y = 0; y < mapWidth; y+=fieldWidth){
                _objects[x, y] = NightPool.Spawn(_prefab, new Vector3(x, 0, y), Quaternion.identity);    
            }               
        }
        return _objects;
    }
}