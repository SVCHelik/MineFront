using UnityEngine;

public enum Type
{
        mainMap
}
[CreateAssetMenu(fileName = "ProcGenData", menuName = "Assets/scenes/cave/ProcGenData", order = 0)]
public class ProcGenData : ScriptableObject {
    [Tooltip("Ширина карты высот, ширина игрового поля")]
    public int mapWidth;
    [Tooltip("Ширина игрового поля")]
    public int fieldWidth;
    [Tooltip("Префаб куба")]
    public GameObject preFub;
   
    [Header("Какие-то сложные параметры для генерации шума")]
    
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
}