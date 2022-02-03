using UnityEngine;

public class Buttons : MonoBehaviour
{
    public LocalizationManager manager;
    private SystemLanguage lang;
    public void SetEnglish()
    {
        lang = SystemLanguage.English;
        manager.SetLocalization(lang);
    }
    public void SetRussian()
    {
        lang = SystemLanguage.Russian;
        manager.SetLocalization(lang);
    }
    public void SetGerman()
    {
        lang = SystemLanguage.German;
        manager.SetLocalization(lang);
    }
}