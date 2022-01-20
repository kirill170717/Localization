using System;
using UnityEngine;
using UnityEngine.UI;

public class Name
{
    public static string image;
}
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
        Invoke("UpdateLocale", 0);
    }

    private void UpdateLocale()
    {
        if (Name.image != null)
        {
            Sprite tmp = Resources.Load("Images/" + Name.image, typeof(Sprite)) as Sprite;
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