using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocaleText : MonoBehaviour
{
    [SerializeField]
    private string textID;

    private Text textComponent;
   
    private void Awake()
    {
        textComponent = GetComponent<Text>();
        LocalizationManager.instance.LanguageChanged += UpdateLocale;
    }

    private void Start()
    {
        UpdateLocale();
    }

    public void UpdateLocale()
    {
        try
        {
            string response = LocalizationManager.instance.GetText(textID);
            if (!string.IsNullOrEmpty(response))
                textComponent.text = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}