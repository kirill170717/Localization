using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleText : MonoBehaviour
{

    [SerializeField]
    string textID; //Идентификатор строкового ресурса, который мы хотим захватить.

    private Text textComponent;
    private LocalizationManager localeManager;
   
    private void Awake()
    {
        //Ссылки на кэш:
        textComponent = GetComponent<Text>();
        localeManager = GameObject.FindWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        localeManager.languageChanged += UpdateLocale;
    }

    private void Start()
    {
        //Убедитесь, что при активации этого объекта отображается правильный язык:
        UpdateLocale();
    }
    /*
    Пытается получить связанный строковый ресурс из LocalizationManager.
    В случае успеха обновляет атрибут text дочернего компонента Text.
    Обратите внимание, что эта функция будет вызвана, даже если этот объект отключен - если включено автообновление.
    */
    public void UpdateLocale()
    {
        try
        {
            string response = localeManager.GetText(textID);
            if (response != null)
                textComponent.text = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}