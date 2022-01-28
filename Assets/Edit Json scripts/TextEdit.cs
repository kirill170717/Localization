using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class TextEdit : MonoBehaviour
{
    private Dictionary<string, string> texts;
    public TextEditor textEditor;

    public void Creating()
    {
        Debug.Log(textEditor.language);
        string path = Application.dataPath + "/Resources/Localizations/" + textEditor.language + ".json";
        if (!File.Exists(path))
            File.WriteAllText(path, "{\n}");
        else
            Debug.Log("The file " + textEditor.language + ".json already exists");
        AssetDatabase.Refresh();
        Outputing();
    }
    public void Removing()
    {
        string path1 = Application.dataPath + "/Resources/Localizations/" + textEditor.language + ".json";
        string path2 = Application.dataPath + "/Resources/Localizations/" + textEditor.language + ".json.meta";
        if (File.Exists(path1) && File.Exists(path2))
        {
            File.Delete(path1);
            File.Delete(path2);
        }
        else
            Debug.Log("The file " + textEditor.language + ".json doesn't exist");
        AssetDatabase.Refresh();
        Outputing();
    }
    public void Outputing()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + textEditor.language.ToString());
        if (textAsset != null)
            textEditor.jsonText = textAsset.text;
        else
            textEditor.jsonText = null;
    }
    public void Loading()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + textEditor.language.ToString());
        if (textAsset != null)
        {
            string path = Application.dataPath + "/Resources/Localizations/" + textEditor.language + ".json";
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            texts.Add(textEditor.key, textEditor.text);
            string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
    public void Deleting()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + textEditor.language.ToString());
        if (textAsset != null)
        {
            string path = Application.dataPath + "/Resources/Localizations/" + textEditor.language + ".json";
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            texts.Remove(textEditor.key);
            string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
}