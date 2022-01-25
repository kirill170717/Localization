using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Edit Json", menuName = "Language/Edit Json", order = 51)]
public class LangEdit : ScriptableObject
{
    [SerializeField]
    public string language;
    [SerializeField]
    public string key;
    [SerializeField]
    public string text;

    [TextArea(minLines: 5, maxLines: 10)]
    public string jsonText;

    public string Language
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

    private JsonEdit jsonEdit;
    public void Output()
    {
        jsonEdit = GameObject.FindWithTag("JsonEdit").GetComponent<JsonEdit>();
        jsonEdit.Outputing();
    }
    public void Load()
    {
        if(key != "" && text != "")
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
        DrawDefaultInspector();
        LangEdit edit = (LangEdit)target;
        if (GUILayout.Button("Выбрать"))
        {
            edit.Output();
        }
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
        GUILayout.Label("Введите название нужного языка в поле 'Language'\n" +
            "и нажмите 'Выбрать', чтобы выбрать язык локализации.\n" +
            "Чтобы добавить перевод, введите ключ в поле 'Key'\n" +
            "и перевод в поле 'Text', чтобы удалить - введите нужный ключ\n" +
            "и нажмите 'Удалить'");
    }
}