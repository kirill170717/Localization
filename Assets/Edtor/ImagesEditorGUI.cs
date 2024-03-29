using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ImagesEditor))]
public class ImagesEditorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ImagesEditor editor = (ImagesEditor)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        editor.key = EditorGUILayout.TextField(editor.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {
            editor.Loading(editor.key);
        }
        else if (GUILayout.Button("Delete"))
        {
            editor.Deleting(editor.key);
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("imgList"), true);
        serializedObject.ApplyModifiedProperties();
    }
}