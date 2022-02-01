using UnityEngine;

public class Buttons : MonoBehaviour
{
    private SystemLanguage lang;
    public void SetEnglish()
    {
        lang = SystemLanguage.English;
        LocalizationManager.SetLocalization(lang);
    }
    public void SetRussian()
    {
        lang = SystemLanguage.Russian;
        LocalizationManager.SetLocalization(lang);
    }
    public void SetGerman()
    {
        lang = SystemLanguage.German;
        LocalizationManager.SetLocalization(lang);
    }
}