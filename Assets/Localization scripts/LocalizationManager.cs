using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
/*
Управляет всеми текстовыми переводами. Должен быть доступен для всего, что имеет текст.
Может дать правильный перевод для любого сохраненного идентификатора.
Автоматически загружает последний использованный язык, если таковой имеется, используя PlayerPrefs.
*/

public class LocalizationManager : MonoBehaviour
{
    [SerializeField]
    private SystemLanguage DefaultLanguage = SystemLanguage.English;

    private SystemLanguage lastLanguage;
    private static SystemLanguage currentLanguage;
    private static Dictionary<string, string> texts;

    //Создайте делегат и события для использования в файлах LocaleText.cs и DictionaryScript.cs:
    public delegate void LanguageChangedEventHandler();
    public static event LanguageChangedEventHandler LanguageChanged;

    private void Awake()
    {
        SystemLanguage newLang = lastLanguage;
        try
        {
            SetLocalization(newLang);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("Trying Default Language: " + DefaultLanguage);
            SetLocalization(DefaultLanguage);
        }
    }
    /*
    Устанавливает текущий язык, используемый функцией getText(), на указанный язык.
    <param name="language">Язык для изменения.</param>
    */
    public static void SetLocalization(SystemLanguage language)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + language);
        if (textAsset != null)
        {
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            currentLanguage = language;
            OnLanguageChanged();
        }
        else
            throw new Exception("Localization Error!: " + language + " does not have a .json resource!");
    }
    /*
    Получить текст по указанному идентификатору.
    <param name="identifier">Идентификатор для поиска в текущей locale.</param>
    <returns>Строка, связанная с идентификатором. Если он не существует, то null.</returns>.
    */
    public static string GetText(string identifier)
    {
        if (!texts.ContainsKey(identifier))
        {
            Debug.Log("Localization Error!: " + identifier + " does not have an associated string!");
            return null;
        }
        return texts[identifier];
    }
    //public static string GetImage(string identifier)
    //{
    //    if (!texts.ContainsKey(identifier))
    //    {
    //        Debug.Log("Localization Error!: " + identifier + " does not have an associated string!");
    //        return null;
    //    }
    //    return texts[identifier];
    //}

    private void OnApplicationQuit()
    {
        lastLanguage = currentLanguage;
    }

    protected static void OnLanguageChanged()
    {
        LanguageChanged?.Invoke();
    }
}