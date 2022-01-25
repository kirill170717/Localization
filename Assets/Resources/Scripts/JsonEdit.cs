using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEditor;

public class JsonEdit : MonoBehaviour
{
    private Dictionary<string, string> texts;
    public LangEdit langEdit;
    public void Outputing()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(langEdit.language);
        if (textAsset != null)
            langEdit.jsonText = textAsset.text;
        else
            langEdit.jsonText = null;
    }
    public void Loading()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(langEdit.language);
        if (textAsset != null)
        {
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            texts.Add(langEdit.key, langEdit.text);
            string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
            File.WriteAllText(Application.dataPath + "/Resources/" + langEdit.language + ".json", json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
    public void Deleting()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(langEdit.language);
        if (textAsset != null)
        {
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            texts.Remove(langEdit.key);
            string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
            File.WriteAllText(Application.dataPath + "/Resources/" + langEdit.language + ".json", json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
}