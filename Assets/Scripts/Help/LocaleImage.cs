using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    private string textID;

    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
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
            Sprite response = LocalizationManager.instance.GetImage(textID);
            if (response != null)
                imageComponent.sprite = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}