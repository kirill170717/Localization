using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Edit Json", menuName = "Language/Edit Json", order = 50)]
public class TextEditor : ScriptableObject
{
    [SerializeField]
    public SystemLanguage language;
    [SerializeField]
    public string key;
    [SerializeField]
    public string text;

    public string jsonText;

    [SerializeField]
    public TextEdit edit;
}

[CustomEditor(typeof(TextEditor))]
public class TextEditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        TextEditor editor = (TextEditor)target;
        editor.edit = (TextEdit)EditorGUILayout.ObjectField("Script", editor.edit, typeof(TextEdit), true);
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Language", GUILayout.MaxWidth(60));
        editor.language = (SystemLanguage)EditorGUILayout.EnumPopup(editor.language);
        if (GUILayout.Button("Создать"))
        {
            editor.edit.Creating(editor.language);
        }
        else if (GUILayout.Button("Удалить"))
        {
            editor.edit.Removing(editor.language);
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Выбрать"))
        {
            editor.edit.Outputing(editor.language);
        }
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        editor.key = EditorGUILayout.TextField(editor.key);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Text", GUILayout.MaxWidth(60));
        editor.text = EditorGUILayout.TextField(editor.text);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Добавить"))
        {
            editor.edit.Loading(editor.language, editor.key, editor.text);
        }
        else if (GUILayout.Button("Удалить"))
        {
            editor.edit.Deleting(editor.language, editor.key);
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUILayout.Label("Выберите нужный язык в поле 'Language'\n" +
            "и нажмите 'Выбрать', чтобы выбрать язык локализации.\n\n" +
            "Если данного языка нет, нажмите 'Создать'.\n" +
            "Для удаления языкового файла нажмите 'Удалить'.\n\n" +
            "Чтобы добавить перевод, введите ключ в поле 'Key'\n" +
            "и перевод в поле 'Text', чтобы удалить - введите нужный\n" +
            "ключ и нажмите 'Удалить'");
        EditorGUILayout.Space();
        editor.jsonText = EditorGUILayout.TextArea(editor.jsonText);
    }
}