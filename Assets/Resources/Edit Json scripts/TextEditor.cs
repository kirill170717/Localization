using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Edit Json", menuName = "Language/Edit Json", order = 51)]
public class TextEditor : ScriptableObject
{
    [SerializeField]
    public SystemLanguage language;
    [SerializeField]
    public string key;
    [SerializeField]
    public string text;
    public string jsonText;

    public SystemLanguage Language
    {
        get { return language; }
    }
    public string Key
    {
        get { return key; }
    }
    public string Text
    {
        get { return text; }
    }

    public TextEdit textEdit;

    public void Create()
    {
        textEdit = GameObject.Find("TextEdit").GetComponent<TextEdit>();
        textEdit.Creating();
    }
    public void Remove()
    {
        textEdit = GameObject.Find("TextEdit").GetComponent<TextEdit>();
        textEdit.Removing();
    }
    public void Output()
    {
        textEdit = GameObject.Find("TextEdit").GetComponent<TextEdit>();
        textEdit.Outputing();
    }
    public void Load()
    {
        if (key != "" && text != "")
        {
            textEdit = GameObject.Find("TextEdit").GetComponent<TextEdit>();
            textEdit.Loading();
        }
        else
            Debug.Log("The 'Key' or 'Text' field is empty");
    }
    public void Delete()
    {
        if (key != "")
        {
            textEdit = GameObject.Find("TextEdit").GetComponent<TextEdit>();
            textEdit.Deleting();
        }
        else
            Debug.Log("The 'Key' field is empty");
    }
}

[CustomEditor(typeof(TextEditor))]
public class EditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        TextEditor edit = (TextEditor)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Language", GUILayout.MaxWidth(60));
        edit.language = (SystemLanguage)EditorGUILayout.EnumPopup(edit.language);
        if (GUILayout.Button("Создать"))
        {
            edit.Create();
        }
        if (GUILayout.Button("Удалить"))
        {
            edit.Remove();
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Выбрать"))
        {
            edit.Output();
        }
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        edit.key = EditorGUILayout.TextField(edit.key);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Text", GUILayout.MaxWidth(60));
        edit.text = EditorGUILayout.TextField(edit.text);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Добавить"))
        {
            edit.Load();
        }
        else if (GUILayout.Button("Удалить"))
        {
            edit.Delete();
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
        edit.jsonText = EditorGUILayout.TextArea(edit.jsonText);
    }
}