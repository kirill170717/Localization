using UnityEngine;

public class JsonEdit : MonoBehaviour
{
    public string data;

    private LangEdit langEdit;

    public void Loading()
    {
        Debug.Log(langEdit.key);
        Debug.Log(langEdit.text);
        data = JsonUtility.ToJson(langEdit);
        Debug.Log(data);
    }
    public void Deleting()
    {

    }
}