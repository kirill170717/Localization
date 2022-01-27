using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ImageEdit : MonoBehaviour
{
    private Dictionary<string, string> images;
    public ImageEditor imageEditor;

    public void Creating()
    {
        string path = Application.dataPath + "/Resources/Image files/" + imageEditor.language + ".json";
        if (!File.Exists(path))
            File.WriteAllText(path, "{\n}");
        else
            Debug.Log("The file " + imageEditor.language + ".json already exists");
        AssetDatabase.Refresh();
        Outputing();
    }
    public void Removing()
    {
        string path1 = Application.dataPath + "/Resources/Image files/" + imageEditor.language + ".json";
        string path2 = Application.dataPath + "/Resources/Image files/" + imageEditor.language + ".json.meta";
        if (File.Exists(path1) && File.Exists(path2))
        {
            File.Delete(path1);
            File.Delete(path2);
        }
        else
            Debug.Log("The file " + imageEditor.language + ".json doesn't exist");
        AssetDatabase.Refresh();
        Outputing();
    }
    public void Outputing()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Image files/" + imageEditor.language.ToString());
        if (textAsset != null)
            imageEditor.jsonText = textAsset.text;
        else
            imageEditor.jsonText = null;
    }
    public void Loading()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Image files/" + imageEditor.language.ToString());
        if (textAsset != null)
        {
            string path = Application.dataPath + "/Resources/Image files/" + imageEditor.language + ".json";
            images = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            images.Add(imageEditor.key, imageEditor.image.ToString());
            string json = JsonConvert.SerializeObject(images, Formatting.Indented);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
    public void Deleting()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Image files/" + imageEditor.language.ToString());
        if (textAsset != null)
        {
            string path = Application.dataPath + "/Resources/Image files/" + imageEditor.language + ".json";
            images = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            images.Remove(imageEditor.key);
            string json = JsonConvert.SerializeObject(images, Formatting.Indented);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Outputing();
        }
    }
}