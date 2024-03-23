using UnityEngine;

public enum mapType
{
        mainMap
}
[CreateAssetMenu(fileName = "ProcGenData", menuName = "Assets/scenes/cave/ProcGenData", order = 0)]
public class ProcGenData : ScriptableObject {
    
    [Tooltip("Тип карты")]
    public mapType type;
    
    [Tooltip("Ширина карты высот, ширина игрового поля")]
    public int mapWidth;
    [Tooltip("Ширина игрового поля")]
    public int fieldWidth;
    [Tooltip("Префаб куба")]
    public GameObject preFub;
   
    [Header("Какие-то сложные параметры для генерации шума")]
    
    [Tooltip("рандомный сид шума")]
    [SerializeField]
    public bool isRandom;

    [Tooltip("сид шума")]
    [SerializeField]
    public int seed;
    [Tooltip("Модификатор шума")]
    [SerializeField]
    public float modifier;
    [Tooltip("Ширина шума")]
    [SerializeField]
    public int width;
    [Tooltip("Масштаб шума")]
    [SerializeField]
    public float scale;
    [Tooltip("Количество октав шума")]
    [SerializeField]
    public int octaves;
    [Tooltip("Сохранение шума")]
    [SerializeField]
    public float persistence;
    [Tooltip("Скорость изменения частоты в разных октавах")]
    [SerializeField]
    public float lacunarity;
}