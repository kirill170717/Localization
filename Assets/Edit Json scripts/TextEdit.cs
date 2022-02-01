using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class TextEdit : MonoBehaviour
{
    public TextEditor editor;

    private static Dictionary<string, string> texts;

    public void Creating(SystemLanguage language)
    {
        string path = Application.dataPath + "/Resources/Localizations/" + language + ".json";
        if (!File.Exists(path))
            File.WriteAllText(path, "{\n}");
        else
            Debug.Log("The file " + language + ".json already exists");
        AssetDatabase.Refresh();
        Outputing(language);
    }
    public void Removing(SystemLanguage language)
    {
        string path = Application.dataPath + "/Resources/Localizations/" + language + ".json";
        if (File.Exists(path))
            File.Delete(path);
        else
            Debug.Log("The file " + language + ".json doesn't exist");
        AssetDatabase.Refresh();
        Outputing(language);
    }
    public void Outputing(SystemLanguage language)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + language.ToString());
        if (textAsset != null)
            editor.jsonText = textAsset.text;
        else
        {
            Debug.Log("The file " + language + ".json doesn't exist");
            editor.jsonText = null;
        }
    }
    public void Loading(SystemLanguage language, string key, string text)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(text))
            Debug.Log("The 'Key' or 'Text' field is empty");
        else
        {
            TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + language.ToString());
            if (textAsset != null)
            {
                string path = Application.dataPath + "/Resources/Localizations/" + language + ".json";
                texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
                texts.Add(key, text);
                string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
                File.WriteAllText(path, json);
                AssetDatabase.Refresh();
                Outputing(language);
            }
            else
                Debug.Log("The file " + language + ".json doesn't exist");
        }
    }
    public void Deleting(SystemLanguage language, string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty");
        else
        {
            TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + language.ToString());
            if (textAsset != null)
            {
                string path = Application.dataPath + "/Resources/Localizations/" + language + ".json";
                texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
                texts.Remove(key);
                string json = JsonConvert.SerializeObject(texts, Formatting.Indented);
                File.WriteAllText(path, json);
                AssetDatabase.Refresh();
                Outputing(language);
            }
            else
                Debug.Log("The file " + language + ".json doesn't exist");
        }
    }
}