using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class TextureGen : MonoBehaviour {
    public static Texture2D GetTexture(int width, float[,] map, GameObject parent)
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
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, width, width), UnityEngine.Vector2.one * 0.5f);
        GameObject spriteObject = new GameObject("GeneratedSprite");
        SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        Instantiate(spriteObject, new UnityEngine.Vector3(2,2,2),quaternion.identity, parent.transform);
        return texture;
    }
    public static Color GetColor(float value)
    {
    float DeepWater = 0.2f;
    float ShallowWater = 0.4f;  
    float Sand = 0.5f;
    float Grass = 0.7f;
    float Forest = 0.8f;
    float Rock = 0.9f;
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
            return DeepColor;
        }
        else if (value < ShallowWater)
        {
            return ShallowColor;
        }
        else if (value < Sand)
        {
            return SandColor;
        }
        else if (value < Grass)
        {
            return GrassColor;
        }
        else if (value < Forest)
        {
            return ForestColor;
        }
        else if (value < Rock)
        {
            return RockColor;
        }
        else
        {
            return SnowColor;
        }
    }

}

