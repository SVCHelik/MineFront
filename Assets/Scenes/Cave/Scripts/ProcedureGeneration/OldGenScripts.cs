using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NTC.Pool;

//using NTC.Pool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Contains all the important functions for generating maps with tilemaps. 
/// Sample algorithyms included are; Random Walk - Both Cave version and Platform version,
/// Cellular Automata, DirectionDungeon, Perlin Noise - Platform version and
/// Custom Procedural Rooms which is experimental
/// </summary>
public class ExpGenScripts: MonoBehaviour{
    
    /// <summary>
    /// Renders a map based on the given integer map, field size, and prefab objects.
    /// </summary>
    /// <param name="map">The integer map representing the tiles.</param>
    /// <param name="fieldSize">The size of the field.</param>
    /// <param name="pref1">The first prefab object.</param>
    /// <param name="pref2">The second prefab object.</param>
    /// <param name="shift">The shift vector.</param>
    /// <returns>The rendered game objects in a 2D array.</returns>
    public static GameObject[,] RenderMap(int[,] map, int fieldSize, GameObject pref1, GameObject pref2, Vector2Int shift)
    {
        int MapWidth = map.GetUpperBound(0);
        Vector2 offset = new Vector2Int(MapWidth/2 - fieldSize/2, MapWidth/2 - fieldSize/2);
        offset+=shift;
        GameObject[,] field = new GameObject[fieldSize, fieldSize];

        for (int x = 0; x < fieldSize ; x++) //Loop through the MapWidth of the map
        {
            for (int y = 0; y < fieldSize; y++) //Loop through the height of the map
            {
                if (map[(int)offset.x+x, (int)offset.y+y] == 1) // 1 = tile, 0 = no tile
                    field[x, y] = NightPool.Spawn(pref1, new Vector3(x, 0, y), Quaternion.identity);
                else 
                    field[x, y] = NightPool.Spawn(pref2, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
        return field;
    }

    /// <summary>
    /// Renders a map using an offset provided, Useful for having multiple maps on one tilemap
    /// </summary>
    /// <param name="map">The map to draw</param>
    /// <param name="tilemap">The tilemap to draw on</param>
    /// <param name="tile">The tile to draw with</param>
    /// <param name="offset">The offset to apply</param>
    public static void RenderMapWithOffset(int[,] map, GameObject pref, Vector2Int offset)
    {
        
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if(map[x,y] == 1)
                {
                    NightPool.Spawn(pref, new Vector3(x + offset.x, y + offset.y ,0), Quaternion.identity);
                }
            }
        }
    }


	/// <summary>
	/// Renders the map but with a delay, this allows us to see it being generated before our eyes
	/// </summary>
	/// <param name="map">The map to draw</param>
	/// <param name="tilemap">The tilemap to draw on</param>
	/// <param name="tile">The tile to draw with</param>
	public static IEnumerator RenderMapWithDelay(int[,] map, Vector2[,] grid, GameObject pref)
    {
        for(int x = 0; x < map.GetUpperBound(0); x++)
        {
            for(int y = 0; y < map.GetUpperBound(1); y++)
            {
                if(map[x,y] == 1)
                {
                    NightPool.Spawn(pref, new Vector3(x , y ,0), Quaternion.identity);
                    yield return null;
                }
            }
        }
    }

    

    public static void despawn(GameObject[,] objects){
        for(int x = 0; x < objects.Length; x++)
            for(int y = 0; y < objects.Length; y++)
                NightPool.Despawn(objects[x,y]);
    }
}