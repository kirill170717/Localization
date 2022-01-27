using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    LocalizationManager manager;
    private string lang;
    public void SetEnglish()
    {
        lang = "English";
        manager = GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>();
        manager.SetLocalization(lang);
    }
    public void SetRussian()
    {
        lang = "Russian";
        manager = GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>();
        manager.SetLocalization(lang);
    }
    public void SetGerman()
    {
        lang = "German";
        manager = GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>();
        manager.SetLocalization(lang);
    }
}