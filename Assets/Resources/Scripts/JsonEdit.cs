using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEditor;

public class JsonEdit : MonoBehaviour
{
    private Dictionary<string, string> texts;
    public LangEdit langEdit;
    public void Creating()
    {
        string path = Application.dataPath + "/Resources/" + langEdit.language + ".json";
        if (!File.Exists(path))
            File.WriteAllText(path, "{\n}");
        else
            Debug.Log("The file " + langEdit.language + ".json already exists");
        AssetDatabase.Refresh();
        Outputing();
    }
    public void Removing()
    {
        string path1 = Application.dataPath + "/Resources/" + langEdit.language + ".json";
        string path2 = Application.dataPath + "/Resources/" + langEdit.language + ".json.meta";
        if (File.Exists(path1) && File.Exists(path2))
        {
            File.Delete(path1);
            File.Delete(path2);
        }
        else
            Debug.Log("The file " + langEdit.language + ".json doesn't exist");
        AssetDatabase.Refresh();
        Outputing();
    }
    public void Outputing()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(langEdit.language.ToString());
        if (textAsset != null)
            langEdit.jsonText = textAsset.text;
        else
            langEdit.jsonText = null;
    }
    public void Loading()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(langEdit.language.ToString());
        if (textAsset != null)
        {
            string path = Application.dataPath + "/Resources/" + langEdit.language + ".json";
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            texts.Add(langEdit.key, langEdit.text);
            string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
    public void Deleting()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(langEdit.language.ToString());
        if (textAsset != null)
        {
            string path = Application.dataPath + "/Resources/" + langEdit.language + ".json";
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            texts.Remove(langEdit.key);
            string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
}