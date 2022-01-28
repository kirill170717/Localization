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
    private string DefaultLanguage = "English";

    private string currentLanguage;
    private Dictionary<string, string> texts;

    //Создайте делегат и события для использования в файле LocaleText.cs:
    public delegate void LanguageChangedEventHandler();
    public event LanguageChangedEventHandler languageChanged;

    private void Awake()
    {
        //Загрузите user preferences, если таковые имеются:
        if (PlayerPrefs.HasKey("LastLanguage"))
        {
            string newLang = PlayerPrefs.GetString("LastLanguage");
            try
            {
                SetLocalization(newLang);
                Lang.language = newLang;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                Debug.Log("Trying Default Language: " + DefaultLanguage);
                SetLocalization(DefaultLanguage);
                Lang.language = DefaultLanguage;
            }
        }
        else
        {
            SetLocalization(DefaultLanguage); //Если нет, мы используем значения по умолчанию.
            Lang.language = DefaultLanguage;
        }
    }
    /*
    Устанавливает текущий язык, используемый функцией getText(), на указанный язык.
    <param name="language">Язык для изменения.</param>
    */
    public void SetLocalization(string language)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + language);
        if (textAsset != null)
        {
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            currentLanguage = language;
            Lang.language = language;
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
    public string GetText(string identifier)
    {
        if (!texts.ContainsKey(identifier))
        {
            Debug.Log("Localization Error!: " + identifier + " does not have an associated string!");
            return null;
        }
        return texts[identifier];
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastLanguage", currentLanguage);
        PlayerPrefs.SetString("Last", Lang.language);
    }

    protected virtual void OnLanguageChanged()
    {
        languageChanged?.Invoke();
    }
}