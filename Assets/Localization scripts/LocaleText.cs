﻿using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleText : MonoBehaviour
{
    [SerializeField]
    string textID; //Идентификатор ресурса, который мы хотим захватить.

    private Text textComponent;
    private LocalizationManager localizationManager;
   
    private void Awake()
    {
        //Ссылки на кэш:
        textComponent = GetComponent<Text>();
        localizationManager = GameObject.Find("LocalizationManager").GetComponent<LocalizationManager>();
        localizationManager.languageChanged += UpdateLocale;
    }

    private void Start()
    {
        //Убедитесь, что при активации этого объекта отображается правильный язык:
        UpdateLocale();
    }
    /*
    Пытается получить связанный строковый ресурс из LocalizationManager.
    В случае успеха обновляет атрибут text дочернего компонента Text.
    */
    public void UpdateLocale()
    {
        try
        {
            string response = localizationManager.GetText(textID);
            if (response != null)
                textComponent.text = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}