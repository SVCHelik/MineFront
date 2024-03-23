using System.Collections;
using UnityEditor.Timeline;
using UnityEngine;

public class Draw: MonoBehaviour
{
    ScriptableObject parametrs;
    RenderScripts ren;
    private GameObject[,] _objects;
    float[,] map;
    GameObject[,] field;
    // Start is called before the first frame update
    [Tooltip("Ширина карты высот, ширина игрового поля")]
    public int mapWidth;
    [Tooltip("Ширина игрового поля")]
    public int fieldWidth;
    [Tooltip("Префаб куба")]
    public GameObject preFub;
    Vector2Int shift = new Vector2Int(0, 0);

    [Tooltip("Какие-то сложные параметры для генерации шума")]
    
    [SerializeField]
    private int seed;
    [Tooltip("Модификатор шума")]
    [SerializeField]
    private float modifier;
    [Tooltip("Ширина шума")]
    [SerializeField]
    private int width;
    [Tooltip("Масштаб шума")]
    [SerializeField]
    private float scale;
    [Tooltip("Количество октав шума")]
    [SerializeField]
    private int octaves;
    [Tooltip("Сохранение шума")]
    [SerializeField]
    private float persistence;
    [Tooltip("Скорость изменения частоты в разных октавах")]
    [SerializeField]
    private float lacunarity;

    GameObject spriteObject;
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    void OnGUI()
    {
        
        if (GUILayout.Button("next"))
        {
            RendNext();
        }
        if (GUILayout.Button("ReGenMapSprite"))
        {
            ReGenMap();
        }
    }
    void Start()
    {
        seed = System.DateTime.Now.Millisecond;
        map = NewGenScripts.GenerateNoiseMap(mapWidth, seed, scale, octaves, persistence, lacunarity, shift);
        ren = new RenderScripts();
        ren.RenderMap(map,field, fieldWidth, preFub, shift);

        sprite = Sprite.Create(TextureGen.GetTexture(width, map), new Rect(0, 0, width, width), UnityEngine.Vector2.one * 0.5f);
        spriteObject = new GameObject("MapSprite");
        spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteObject.transform.parent = Camera.main.transform;
        // Устанавливаем позицию и ориентацию спрайта относительно камеры
        spriteObject.transform.localPosition = new Vector3(1.52f, 0.58f, 2f); // Размещаем спрайт перед камерой на расстоянии 2 метра
        spriteObject.transform.localRotation = Quaternion.identity; // Выравниваем спрайт так, чтобы он был направлен прямо перед камерой
    }
    void ReGenMap()//только для спрайта(пока)
    {
        seed = System.DateTime.Now.Millisecond;
        map = NewGenScripts.GenerateNoiseMap(mapWidth, seed, scale, octaves, persistence, lacunarity, shift);
        sprite = Sprite.Create(TextureGen.GetTexture(width, map), new Rect(0, 0, width, width), UnityEngine.Vector2.one * 0.5f);
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {
        //StartCoroutine("RendNext", 1);
    }
    IEnumerator RendNext(){
        shift.x = (shift.x+fieldWidth)%mapWidth;
        shift.y = (shift.y+fieldWidth)%mapWidth;
        ren.RenderMap(map,field, fieldWidth, preFub, shift);
        return null;
    }
}

