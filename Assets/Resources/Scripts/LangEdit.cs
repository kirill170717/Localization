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
        if (GUILayout.Button("�������"))
        {
            edit.Output();
        }
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
        GUILayout.Label("������� �������� ������� ����� � ���� 'Language'\n" +
            "� ������� '�������', ����� ������� ���� �����������.\n" +
            "����� �������� �������, ������� ���� � ���� 'Key'\n" +
            "� ������� � ���� 'Text', ����� ������� - ������� ������ ����\n" +
            "� ������� '�������'");
    }
}