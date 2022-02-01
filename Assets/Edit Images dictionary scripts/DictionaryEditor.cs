using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Images Dictionary", menuName = "Language/Images Dictionary", order = 50)]
public class DictionaryEditor : ScriptableObject
{
    [Serializable]
    public class ImgDict
    {
        public SystemLanguage language;
        public Sprite sprite;
    }
    [SerializeField]
    public string key;
    [SerializeField]
    public List<ImgDict> images = new List<ImgDict>();

    public Dictionary<string, List<ImgDict>> imagesDictionary = new Dictionary<string, List<ImgDict>>();

    [Serializable]
    public class DictList
    {
        public string key;
        public List<ImgDict> imagesList = new List<ImgDict>();
    }
    [SerializeField]
    public List<DictList> imgList = new List<DictList>();

    public void OutputDict()
    {
        
    }

    [SerializeField]
    public DictionaryEdit edit;
}



[CustomEditor(typeof(DictionaryEditor))]
public class DictionaryEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DictionaryEditor editor = (DictionaryEditor)target;
        editor.edit = (DictionaryEdit)EditorGUILayout.ObjectField("Script", editor.edit, typeof(DictionaryEdit), true);
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        editor.key = EditorGUILayout.TextField(editor.key);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("images"), true);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Добавить"))
        {
            editor.edit.Loading(editor.key, editor.images);
        }
        else if (GUILayout.Button("Удалить"))
        {
            editor.edit.Deleting(editor.key);
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("imgList"), true);
        serializedObject.ApplyModifiedProperties();
    }
}