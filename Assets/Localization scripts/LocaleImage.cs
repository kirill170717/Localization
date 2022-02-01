using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    string textID; //Идентификатор ресурса, который мы хотим захватить.

    private Sprite spriteComponent;

    private void Awake()
    {
        //Ссылки на кэш:
        spriteComponent = GetComponent<Sprite>();
        LocalizationManager.LanguageChanged += UpdateLocale;
    }

    private void Start()
    {
        //Убедитесь, что при активации этого объекта отображается правильный язык:
        UpdateLocale();
    }
    /*
    Пытается получить связанный строковый ресурс из LocalizationManager.
    В случае успеха обновляет атрибут text дочернего компонента Text.
    */
    public void UpdateLocale()
    {
        //try
        //{
        //    Sprite response = LocalizationManager.GetImage(textID);
        //    if (response != null)
        //        spriteComponent = response;
        //}
        //catch (NullReferenceException e)
        //{
        //    Debug.Log(e);
        //}
    }





    //[SerializeField]
    //private DictionaryScriptableObject dictionaryData;
    //public string Key; //Идентификатор ресурса, который мы хотим захватить.

    //private string key;
    //private string defaultkey = "English";
    //private Dictionary<string, Sprite> imagesDictionary = new Dictionary<string, Sprite>();

    //private void Awake()
    //{
    //    for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Sprites.Count); i++)
    //    {
    //        imagesDictionary.Add(dictionaryData.Keys[i], dictionaryData.Sprites[i]);
    //    }

    //    if (PlayerPrefs.HasKey("Last"))
    //    {
    //        string last = PlayerPrefs.GetString("Last") + "_" + Key;
    //        try
    //        {
    //            GetComponent<Image>().sprite = imagesDictionary[last];
    //        }
    //        catch (Exception e)
    //        {
    //            Debug.Log(e);
    //            Debug.Log("Trying Default: " + defaultkey);
    //            Lang.language = defaultkey + "_" + Key;
    //            GetComponent<Image>().sprite = imagesDictionary[Lang.language];
    //        }
    //    }
    //    else
    //    {
    //        Lang.language = defaultkey + "_" + Key;
    //        GetComponent<Image>().sprite = imagesDictionary[Lang.language]; //Если нет, мы используем значения по умолчанию.
    //    }
    //    //Ссылки на кэш:
    //    LocalizationManager.languageChanged += UpdateLocale;

    //}
    ////Выставляет изображение в соответствии с ключом.
    //public void UpdateLocale()
    //{
    //    key = Lang.language + "_" + Key;
    //    try
    //    {
    //        GetComponent<Image>().sprite = imagesDictionary[key];
    //    }
    //    catch (NullReferenceException e)
    //    {
    //        Debug.Log(e);
    //    }
    //}
}