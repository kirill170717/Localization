using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public void Change(int number)
    {
        switch (number)
        {
            case 1:
                LocalizationManager.instance.SetLocalization(SystemLanguage.English);
                break;
            case 2:
                LocalizationManager.instance.SetLocalization(SystemLanguage.Russian);
                break;
            case 3:
                LocalizationManager.instance.SetLocalization(SystemLanguage.German);
                break;
        }
    }
}