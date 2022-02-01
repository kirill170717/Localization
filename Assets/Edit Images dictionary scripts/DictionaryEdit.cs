using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryEdit : MonoBehaviour
{
    public DictionaryEditor editor;
    public void Loading(string key, List<DictionaryEditor.ImgDict> images)
    {
        if (string.IsNullOrEmpty(key) || images.Count <= 0)
            Debug.Log("The 'Key' or 'Images' field is empty");
        else
        {
            if (editor.imagesDictionary.ContainsKey(key))
                Debug.Log("The 'Key' already exists");
            else
            {
                editor.imagesDictionary.Add(key, images);
                foreach (KeyValuePair<string, List<DictionaryEditor.ImgDict>> i in editor.imagesDictionary)
                    Debug.Log(i.Key + " : " + i.Value);
                editor.OutputDict();
            }
        }
    }
    public void Deleting(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty");
        else
        {
            if (!editor.imagesDictionary.ContainsKey(key))
                Debug.Log("The 'Key' doesn't exist");
            else
            {
                editor.imagesDictionary.Remove(key);
                foreach (KeyValuePair<string, List<DictionaryEditor.ImgDict>> i in editor.imagesDictionary)
                    Debug.Log(i.Key + " : " + i.Value);
                editor.OutputDict();
            }
        }
    }
}