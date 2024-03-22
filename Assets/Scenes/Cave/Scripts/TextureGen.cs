using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class TextureGen : MonoBehaviour {
    public static Texture2D GetTexture(int width, float[,] map)
    {
        var texture = new Texture2D(width, width);
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < width; y++)
            {
    
                texture.SetPixel(x, y,  GetColor(map[x,y]));
                
            }
        }
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.Apply();
        return texture;
    }
    public static Color GetColor(float value, int height = 0)
    {
    float DeepWater = 2f;
    float ShallowWater = 4f;  
    float Sand = 5f;
    float Grass = 7f;
    float Forest = 8f;
    float Rock = 9f;
    Color DeepColor = new Color(0, 0, 0.5f, 1);
    Color ShallowColor = new Color(25/255f, 25/255f, 150/255f, 1);
    Color SandColor = new Color(240 / 255f, 240 / 255f, 64 / 255f, 1);
    Color GrassColor = new Color(50 / 255f, 220 / 255f, 20 / 255f, 1);
    Color ForestColor = new Color(16 / 255f, 160 / 255f, 0, 1);
    Color RockColor = new Color(0.5f, 0.5f, 0.5f, 1);            
    Color SnowColor = new Color(1, 1, 1, 1);
        //HeightMap Analyze
        if (value < DeepWater)
        {
            height = (int)Mathf.Floor(DeepWater*10);
            return DeepColor;
        }
        else if (value < ShallowWater)
        {
            height = (int)Mathf.Floor(ShallowWater*10);
            return ShallowColor;
        }
        else if (value < Sand)
        {
            height = (int)Mathf.Floor(Sand*10);
            return SandColor;
        }
        else if (value < Grass)
        {
            height = (int)Mathf.Floor(Grass*10);
            return GrassColor;
        }
        else if (value < Forest)
        {
            height = (int)Mathf.Floor(Forest*10);
            return ForestColor;
        }
        else if (value < Rock)
        {
            height = (int)Mathf.Floor(Rock*10);
            return RockColor;
        }
        else
        {
            height = 1;
            return SnowColor;
        }
    }

}

