using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Data Objects/Dictionary Storage Object")]
public class DictionaryScriptableObject : ScriptableObject
{
    [SerializeField]
    List<string> keys = new List<string>();
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();

    public List<string> Keys { get => keys; set => keys = value; }
    public List<Sprite> Sprites { get => sprites; set => sprites = value; }
}

[CustomEditor(typeof(DictionaryScriptableObject))]
public class DictionaryEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DictionaryScriptableObject edit = (DictionaryScriptableObject)target;
        GUILayout.Label("Поле 'Key' заполняется в формате\n" +
            "'Language_KeyName'.\n" +
            "Порядковый номер ключа соответствует\n" +
            "порядковому номеру изображения.");
    }
}