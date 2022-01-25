using System;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Edit Json", menuName = "Language/Edit Json", order = 51)]
public class LangEdit : ScriptableObject
{
    [SerializeField]
    public string key;
    [SerializeField]
    public string text;

    public string Key
    {
        get { return key; }
    }
    public string Text
    {
        get { return text; }
    }

    private JsonEdit jsonEdit;
    public void Load()
    {
        jsonEdit.Loading();
    }
    public void Delete()
    {
        jsonEdit.Deleting();
    }
}

[CustomEditor(typeof(LangEdit))]
public class EditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LangEdit edit = (LangEdit)target;
        if (GUILayout.Button("Добавить"))
        {
            edit.Load();
        }
        else if (GUILayout.Button("Удалить"))
        {
            edit.Delete();
        }
    }
}