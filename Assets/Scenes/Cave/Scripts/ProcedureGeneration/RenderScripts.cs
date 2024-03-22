using UnityEngine;
using NTC.Pool;
using System.Collections;
public class RenderScripts{
    public GameObject[,] RenderMap(float[,] map, GameObject[,] field, int fieldSize, GameObject pref, Vector2Int shift)
    {
        int mapWidth = map.GetUpperBound(0);
        Vector2Int offset = new Vector2Int(mapWidth/2 - fieldSize/2, mapWidth/2 - fieldSize/2)+shift;
        offset.x %= mapWidth - fieldSize;
        offset.y %= mapWidth - fieldSize;
        field = new GameObject[fieldSize, fieldSize];
        int i = 0;
        for (int x = 0; x < fieldSize ; x++) //Loop through the mapWidth of the map
        {
            i++;
            for (int y = 0; y < fieldSize; y++) //Loop through the height of the map
            {
                i++;
                field[x, y] =  NightPool.Spawn(pref, new Vector3(x+offset.x, map[x+offset.x, y+offset.y], y + offset.y), Quaternion.identity);
                Renderer renderer = field[x,y].GetComponent<Renderer>();
                renderer.material.color = TextureGen.GetColor(map[x+offset.x, y + offset.y]);
            }
        }
        return field;
    }
   public  IEnumerator RenderMapWithDelay(float[,] map, GameObject[,] field, int fieldSize, GameObject pref, Vector2Int shift)
    {
        int mapWidth = map.GetUpperBound(0);
        Vector2Int offset = new Vector2Int(mapWidth/2 - fieldSize/2, mapWidth/2 - fieldSize/2)+shift;
        field = new GameObject[fieldSize, fieldSize];
        int i = 0;
        for (int x = 0; x < fieldSize ; x++) //Loop through the mapWidth of the map
        {
            i++;
            for (int y = 0; y < fieldSize; y++) //Loop through the height of the map
            {
                i++;
                field[x, y] =  NightPool.Spawn(pref, new Vector3(x+offset.x, map[x+offset.x, y+offset.y], y + offset.y), Quaternion.identity);
                Renderer renderer = field[x,y].GetComponent<Renderer>();
                renderer.material.color = TextureGen.GetColor(map[x+offset.x, y + offset.y]);
            }
        }
        yield return new WaitForSeconds(3);
    }
 }