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
        if (GUILayout.Button("�������"))
        {
            edit.Create();
        }
        if (GUILayout.Button("�������"))
        {
            edit.Remove();
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("�������"))
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
        if (GUILayout.Button("��������"))
        {
            edit.Load();
        }
        else if (GUILayout.Button("�������"))
        {
            edit.Delete();
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUILayout.Label("�������� ������ ���� � ���� 'Language'\n" +
            "� ������� '�������', ����� ������� ���� �����������.\n\n" +
            "���� ������� ����� ���, ������� '�������'.\n" +
            "��� �������� ��������� ����� ������� '�������'.\n\n" +
            "����� �������� �������, ������� ���� � ���� 'Key'\n" +
            "� ������� � ���� 'Text', ����� ������� - ������� ������\n" +
            "���� � ������� '�������'");
        EditorGUILayout.Space();
        edit.jsonText = EditorGUILayout.TextArea(edit.jsonText);
    }
}