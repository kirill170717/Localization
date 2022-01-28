using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang
{
    public static string language;
}

[RequireComponent(typeof(Image))]
//Предоставляет возможность во время выполнения манипулировать родственным спрайтовым компонентом, чтобы он соответствовал текущей Locale.
public class DictionaryScript : MonoBehaviour
{
    [SerializeField]
    private DictionaryScriptableObject dictionaryData;
    public string Key; //Идентификатор ресурса, который мы хотим захватить.

    private string key;
    private string defaultkey = "English";
    private LocalizationManager localizationManager;
    private Dictionary<string, Sprite> imagesDictionary = new Dictionary<string, Sprite>();

    private void Awake()
    {
        for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Sprites.Count); i++)
        {
            imagesDictionary.Add(dictionaryData.Keys[i], dictionaryData.Sprites[i]);
        }

        if (PlayerPrefs.HasKey("Last"))
        {
            string last = PlayerPrefs.GetString("Last") + "_" + Key;
            try
            {
                GetComponent<Image>().sprite = imagesDictionary[last];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                Debug.Log("Trying Default: " + defaultkey);
                Lang.language = defaultkey + "_" + Key;
                GetComponent<Image>().sprite = imagesDictionary[Lang.language];
            }
        }
        else
        {
            Lang.language = defaultkey + "_" + Key;
            GetComponent<Image>().sprite = imagesDictionary[Lang.language]; //Если нет, мы используем значения по умолчанию.
        }
        //Ссылки на кэш:
        localizationManager = GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>();
        localizationManager.languageChanged += UpdateLocale;

    }
    //Выставляет изображение в соответствии с ключом.
    public void UpdateLocale()
    {
        key = Lang.language + "_" + Key;
        try
        {
            GetComponent<Image>().sprite = imagesDictionary[key];
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}