using UnityEngine;
public class Draw: MonoBehaviour
{
    
    private GameObject[,] _objects;
    float[,] map;
    // Start is called before the first frame update
    [Tooltip("Ширина карты высот, ширина игрового поля")]
    public int mapWidth;
    [Tooltip("Ширина игрового поля")]
    public int fieldWidth;
    [Tooltip("Префаб куба")]
    public GameObject pref;
    public GameObject quad;
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


    void OnGUI()
    {
        
        if (GUILayout.Button("next"))
        {
            shift.x += fieldWidth;
        }
        if (GUILayout.Button("generate"))
        {
            ReGen();
        }
    }
    void Start()
    {
        seed = System.DateTime.Now.Millisecond;
        map = NewGenScripts.GenerateNoiseMap(mapWidth, seed, scale, octaves, persistence, lacunarity, shift);
        RenderScripts ren = new RenderScripts();
        ren.RenderMap(map, fieldWidth, pref, shift);
        quad = GameObject.Find("Quad");
        quad.GetComponent<Renderer>().material.SetTexture("hello", TextureGen.GetTexture(mapWidth, map, null));
        
    }
    void ReGen()
    {
        seed = System.DateTime.Now.Millisecond;
        //улучшенная функция шума
        map = NewGenScripts.GenerateNoiseMap(mapWidth, seed, scale, octaves, persistence, lacunarity, shift);
        //отрисовка
        TextureGen.GetTexture(mapWidth, map, GameObject.Find("quad"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}

