using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LocaleImage : MonoBehaviour
{
    public Image image;
    public static void SetImage()
    {
        LocaleImage[] image = GameObject.FindObjectsOfType<LocaleImage>();
        for (int i = 0; i < image.Length; i++)
            image[i].UpdateImage();
    }
    public void UpdateImage()
    {
        if (!image) return;
        Invoke(nameof(UpdateLocale), 0);
    }

    private void UpdateLocale()
    {
        Sprite tmp = Resources.Load("Images/English", typeof(Sprite)) as Sprite;
        if (tmp != null)
            image.sprite = tmp;
        UpdateImage();
    }

    private void Start()
    {
        image = GetComponent<Image>();
        UpdateImage();
    }
}