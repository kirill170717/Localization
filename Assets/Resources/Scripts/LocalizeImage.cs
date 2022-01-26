using UnityEngine;
using UnityEngine.UI;

public class Images : ScriptableObject
{
    
}

[RequireComponent(typeof(Image))]
public class LocalizeImage : MonoBehaviour
{
    public Image image;
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
        //Sprite tmp = Resources.Load("Images/" + , typeof(Sprite)) as Sprite;
        //if (tmp != null)
        //    image.sprite = tmp;
        //UpdateImage();
    }

    private void Start()
    {
        image = GetComponent<Image>();
        UpdateImage();
    }
}