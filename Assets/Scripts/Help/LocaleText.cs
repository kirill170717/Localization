using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocaleText : MonoBehaviour
{
    public string TextID;

    private TMP_Text _textComponent;
   
    private void Awake()
    {
        _textComponent = GetComponent<TMP_Text>();
        LocalizationManager.OnLanguageChanged += UpdateLocale;
    }

    private void Start()
    {
        UpdateLocale();
    }

    private void UpdateLocale()
    {
        try
        {
            string response = LocalizationManager.OnTextReceived.Invoke(TextID);

            if (!string.IsNullOrEmpty(response))
            {
                _textComponent.text = response;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}