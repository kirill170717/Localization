using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class LocalizeImage : MonoBehaviour
{
    private Image image;
    public static void SetImage()
    {
        LocalizeImage[] image = GameObject.FindObjectsOfType<LocalizeImage>();
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
        if (Name.Language != null)
        {
            Sprite tmp = Resources.Load("Images/" + Name.Language, typeof(Sprite)) as Sprite;
            if (tmp != null)
                image.sprite = tmp;
            return;
        }
        UpdateImage();
    }

    private void Start()
    {
        image = GetComponent<Image>();
        UpdateImage();
    }
}