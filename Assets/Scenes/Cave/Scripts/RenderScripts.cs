using UnityEngine;
using NTC.Pool;
public class RenderScripts{
    public GameObject[,] RenderMap(float[,] map, int fieldSize, GameObject pref, Vector2Int shift)
    {
        int MapWidth = map.GetUpperBound(0);
        Vector2Int offset = new Vector2Int(MapWidth/2 - fieldSize/2, MapWidth/2 - fieldSize/2)+shift;
        GameObject[,] field = new GameObject[fieldSize, fieldSize];
        int i = 0;
        for (int x = 0; x < fieldSize ; x++) //Loop through the MapWidth of the map
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

}