using UnityEngine;
using System;
public class LocalizationManager : MonoBehaviour
{
    public SystemLanguage DefaultLanguage = SystemLanguage.English;

    private SystemLanguage _currentLanguage;

    public TextEditor TextEditor;
    public ImagesEditor DictionaryEditor;

    public static Action OnLanguageChanged;
    public static Action<SystemLanguage> OnLanguageSet;

    public static Func<string, string> OnTextReceived;
    public static Func<string, Sprite> OnImageReceived;

    private void Awake()
    {
        OnLanguageSet += SetLocalization;
        OnTextReceived += GetText;
        OnImageReceived += GetImage;

        if (PlayerPrefs.HasKey("LastLanguage"))
        {
            SystemLanguage newLang = (SystemLanguage)PlayerPrefs.GetInt("LastLanguage");
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
            SetLocalization(DefaultLanguage);
    }

    public void SetLocalization(SystemLanguage language)
    {
        _currentLanguage = language;
        OnLanguageChanged.Invoke();
    }

    public string GetText(string identifier)
    {
        string text;
        if (TextEditor.txtList.Exists(x => x.key == identifier))
        {
            int keyId = TextEditor.txtList.FindIndex(x => x.key == identifier);
            if (TextEditor.txtList[keyId].textsList.Exists(x => x.language == _currentLanguage))
            {
                int textId = TextEditor.txtList[keyId].textsList.FindIndex(x => x.language == _currentLanguage);
                text = TextEditor.txtList[keyId].textsList[textId].text;
                return text;
            }
            else
                Debug.Log("Localization Error!: The '" + _currentLanguage + "' key doesn't exist!");
        }
        else
            Debug.Log("Localization Error!: The '" + identifier + "' key doesn't exist!");
        return null;
    }

    public Sprite GetImage(string identifier)
    {
        Sprite sprite;
        if (DictionaryEditor.imgList.Exists(x => x.key == identifier))
        {
            int keyId = DictionaryEditor.imgList.FindIndex(x => x.key == identifier);
            if (DictionaryEditor.imgList[keyId].imagesList.Exists(x => x.language == _currentLanguage))
            {
                int textId = DictionaryEditor.imgList[keyId].imagesList.FindIndex(x => x.language == _currentLanguage);
                sprite = DictionaryEditor.imgList[keyId].imagesList[textId].sprite;
                return sprite;
            }
            else
                Debug.Log("Localization Error!: The '" + _currentLanguage + "' key doesn't exist!");
        }
        else
            Debug.Log("Localization Error!: The '" + identifier + "' key doesn't exist!");
        return null;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LastLanguage", (int)_currentLanguage);
    }
}