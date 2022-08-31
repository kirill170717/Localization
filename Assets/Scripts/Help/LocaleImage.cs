using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
public class LocaleImage : MonoBehaviour
{
    public string TextID;

    private Image _imageComponent;

    private void Awake()
    {
        _imageComponent = GetComponent<Image>();
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
            Sprite response = LocalizationManager.OnImageReceived.Invoke(TextID);

            if (response != null)
            {
                _imageComponent.sprite = response;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}