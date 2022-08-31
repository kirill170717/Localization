using UnityEngine;

public class SwitchLanguage : MonoBehaviour
{
    public void Change(int number)
    {
        switch (number)
        {
            case 1:
                LocalizationManager.OnLanguageSet.Invoke(SystemLanguage.English);
                break;
            case 2:
                LocalizationManager.OnLanguageSet.Invoke(SystemLanguage.Russian);
                break;
            case 3:
                LocalizationManager.OnLanguageSet.Invoke(SystemLanguage.German);
                break;
        }
    }
}