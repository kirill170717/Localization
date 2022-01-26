using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Edit Json", menuName = "Language/Edit Json", order = 51)]
public class LangEdit : ScriptableObject
{
    [SerializeField]
    public SystemLanguage language;
    [SerializeField]
    public string key;
    [SerializeField]
    public string text;

    [TextArea(minLines: 5, maxLines: 10)]
    public string jsonText;

    public string Language
    {
        get { return language.ToString(); }
    }
    public string Key
    {
        get { return key; }
    }
    public string Text
    {
        get { return text; }
    }

    private JsonEdit jsonEdit;
    public void Create()
    {
        jsonEdit = GameObject.FindWithTag("JsonEdit").GetComponent<JsonEdit>();
        jsonEdit.Creating();
    }
    public void Remove()
    {
        jsonEdit = GameObject.FindWithTag("JsonEdit").GetComponent<JsonEdit>();
        jsonEdit.Removing();
    }
    public void Output()
    {
        jsonEdit = GameObject.FindWithTag("JsonEdit").GetComponent<JsonEdit>();
        jsonEdit.Outputing();
    }
    public void Load()
    {
        if (key != "" && text != "")
        {
            jsonEdit = GameObject.FindWithTag("JsonEdit").GetComponent<JsonEdit>();
            jsonEdit.Loading();
        }
    }
    public void Delete()
    {
        if (key != "")
        {
            jsonEdit = GameObject.FindWithTag("JsonEdit").GetComponent<JsonEdit>();
            jsonEdit.Deleting();
        }
    }
}

[CustomEditor(typeof(LangEdit))]
public class EditGUI : Editor
{
    public override void OnInspectorGUI()
    {
        LangEdit edit = (LangEdit)target;
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