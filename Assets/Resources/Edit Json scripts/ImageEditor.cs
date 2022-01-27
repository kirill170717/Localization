using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Edit Image", menuName = "Language/Edit Image", order = 51)]
public class ImageEditor : ScriptableObject
{
    [SerializeField]
    public SystemLanguage language;
    [SerializeField]
    public string key;
    [SerializeField]
    public Sprite image;
    public string jsonText;

    public SystemLanguage Language
    {
        get { return language; }
    }
    public string Key
    {
        get { return key; }
    }
    public Sprite Image
    {
        get { return image; }
    }

    public ImageEdit imageEdit;

    public void Create()
    {
        imageEdit = GameObject.Find("ImageEdit").GetComponent<ImageEdit>();
        imageEdit.Creating();
    }
    public void Remove()
    {
        imageEdit = GameObject.Find("ImageEdit").GetComponent<ImageEdit>();
        imageEdit.Removing();
    }
    public void Output()
    {
        imageEdit = GameObject.Find("ImageEdit").GetComponent<ImageEdit>();
        imageEdit.Outputing();
    }
    public void Load()
    {
        if (key != "" && image != null)
        {
            imageEdit = GameObject.Find("ImageEdit").GetComponent<ImageEdit>();
            imageEdit.Loading();
        }
        else
            Debug.Log("The 'Key' or 'Sprite' field is empty");
    }
    public void Delete()
    {
        if (key != "")
        {
            imageEdit = GameObject.Find("ImageEdit").GetComponent<ImageEdit>();
            imageEdit.Deleting();
        }
        else
            Debug.Log("The 'Key' field is empty");
    }
}

[CustomEditor(typeof(ImageEditor))]
public class EditImage : Editor
{
    public override void OnInspectorGUI()
    {
        ImageEditor edit = (ImageEditor)target;
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
        edit.image = (Sprite)EditorGUILayout.ObjectField("Sprite", edit.image, typeof(Sprite), true);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

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
            "� ������� '�������', ����� ������� ����\n" +
            "� �������������.\n\n" +
            "���� ������� ����� ���, ������� '�������'.\n" +
            "��� �������� ����� ������� '�������'.\n\n" +
            "����� �������� �����������, �������\n" +
            "���� � ���� 'Key' � �������� �����������\n" +
            "� ���� 'Sprite', ����� ������� - �������\n" +
            "������ ���� � ������� '�������'.");
        EditorGUILayout.Space();
        edit.jsonText = EditorGUILayout.TextArea(edit.jsonText);
    }
}