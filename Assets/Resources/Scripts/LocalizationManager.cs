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
    private Dictionary<string, string> texts;

    [SerializeField]
    public List<SystemLanguage> languages = new List<SystemLanguage>();

    [SerializeField]
    private string DefaultLanguage = "English";
    private string currentLanguage;

    //Создайте делегат и события для использования в файле LocaleText.cs:
    public delegate void LanguageChangedEventHandler();
    public event LanguageChangedEventHandler languageChanged;

    private void Awake()
    {
        //Загрузите user preferences, если таковые имеются:
        if (PlayerPrefs.HasKey("LAST_LANGUAGE"))
        {
            string newLang = PlayerPrefs.GetString("LAST_LANGUAGE");
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
        else
        {
            SetLocalization(DefaultLanguage); //Если нет, мы используем значения по умолчанию.
        }
    }
    /*
    Устанавливает текущий язык, используемый функцией getText(), на указанный язык.
    <param name="language">Язык для изменения.</param>
    */
    public void SetLocalization(string language)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(language);
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
        PlayerPrefs.SetString("LAST_LANGUAGE", currentLanguage);
    }

    protected virtual void OnLanguageChanged()
    {
        languageChanged?.Invoke();
        LocalizeImage.SetImage();
    }
}