using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Draw: MonoBehaviour
{
    float[,] map;
    GameObject[,] field;
    // Start is called before the first frame update
    Vector2Int shift = new Vector2Int(0, 0);

    private GameObject[,] _objects;
    GameObject spriteObject;
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    public ProcGenData settings;
    RenderScripts ren;
    public void MapInit(){
		int seed;
		if (settings.isRandom)
		{
			seed = DateTime.Now.Millisecond;
		}
		else
		{
			seed = settings.seed;
		}

		switch (settings.type)
		{
			case mapType.mainMap:
                map = NewGenScripts.GenerateNoiseMap(settings, seed);
                break;
        }

    }
    void OnGUI()
    {
        
        if (GUILayout.Button("next"))
        {
            //RendNext();
        }
        if (GUILayout.Button("ReGenMapSprite"))
        {
            ReGenMap();
        }
    }
    void Start()
    {
        MapInit();
        ren = new RenderScripts();
        ren.RenderMap(map,field, settings.fieldWidth, settings.preFub, shift);

        sprite = Sprite.Create(TextureGen.GetTexture(map.GetUpperBound(0), map), new Rect(0, 0, map.GetUpperBound(0), map.GetUpperBound(0)), UnityEngine.Vector2.one * 0.5f);
        spriteObject = new GameObject("MapSprite");
        spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteObject.transform.parent = Camera.main.transform;
        // Устанавливаем позицию и ориентацию спрайта относительно камеры
        spriteObject.transform.localPosition = new Vector3(1.52f, 0.58f, 2f); // Размещаем спрайт перед камерой на расстоянии 2 метра
        spriteObject.transform.localRotation = Quaternion.identity; // Выравниваем спрайт так, чтобы он был направлен прямо перед камерой
    }
    public void gensprite(){
        sprite = Sprite.Create(TextureGen.GetTexture(map.GetUpperBound(0), map), new Rect(0, 0, map.GetUpperBound(0), map.GetUpperBound(0)), UnityEngine.Vector2.one * 0.5f);
        spriteRenderer.sprite = sprite;
    }
    void ReGenMap()//только для спрайта(пока)
    {
        MapInit();
        gensprite();
    }

    void Update()
    {
        //StartCoroutine("RendNext", 1);
    }
    // IEnumerator RendNext(){
    //     shift.x = (shift.x+fieldWidth)%mapWidth;
    //     shift.y = (shift.y+fieldWidth)%mapWidth;
    //     ren.RenderMap(map,field, fieldWidth, preFub, shift);
    //     return null;
    // }
}

