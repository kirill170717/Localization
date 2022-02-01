using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
//������������� ����������� �� ����� ���������� �������������� ����������� ��������� �����������, ����� �� �������������� ������� Locale.
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    string textID; //������������� �������, ������� �� ����� ���������.

    private Sprite spriteComponent;

    private void Awake()
    {
        //������ �� ���:
        spriteComponent = GetComponent<Sprite>();
        LocalizationManager.LanguageChanged += UpdateLocale;
    }

    private void Start()
    {
        //���������, ��� ��� ��������� ����� ������� ������������ ���������� ����:
        UpdateLocale();
    }
    /*
    �������� �������� ��������� ��������� ������ �� LocalizationManager.
    � ������ ������ ��������� ������� text ��������� ���������� Text.
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
    //public string Key; //������������� �������, ������� �� ����� ���������.

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
    //        GetComponent<Image>().sprite = imagesDictionary[Lang.language]; //���� ���, �� ���������� �������� �� ���������.
    //    }
    //    //������ �� ���:
    //    LocalizationManager.languageChanged += UpdateLocale;

    //}
    ////���������� ����������� � ������������ � ������.
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