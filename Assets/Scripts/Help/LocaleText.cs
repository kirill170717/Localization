using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocaleText : MonoBehaviour
{
    [SerializeField]
    private string textID;

    private TMP_Text textComponent;
   
    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        LocalizationManager.OnLanguageChanged += UpdateLocale;
    }

    private void Start()
    {
        UpdateLocale();
    }

    public void UpdateLocale()
    {
        try
        {
            string response = LocalizationManager.OnTextReceived.Invoke(textID);
            if (!string.IsNullOrEmpty(response))
                textComponent.text = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}