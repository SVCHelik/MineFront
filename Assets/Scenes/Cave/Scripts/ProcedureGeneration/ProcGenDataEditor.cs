
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProcGenData))]
public class ProcGenDataEditor : Editor {
    public override void OnInspectorGUI()
    {
        
        serializedObject.Update();
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Параметры генерации карты", EditorStyles.boldLabel);
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("type"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mapWidth"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("fieldWidth"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("preFub"));
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Параметры генерации шума", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isRandom"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("seed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("modifier"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("width"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("scale"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("octaves"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("persistence"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("lacunarity"));
        
        serializedObject.ApplyModifiedProperties();
    }

}