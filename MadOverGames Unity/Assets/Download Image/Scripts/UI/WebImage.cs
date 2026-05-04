using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WebImage : MonoBehaviour
{
    public string url;
    public bool cacheInMemory = true;

    private Image img;
    private Sprite defaultSprite;

    private void Awake()
    {
        img = GetComponent<Image>();
        defaultSprite = img.sprite;
    }

    private void Start()
    {
        if (string.IsNullOrEmpty(url)) return;

        DownloadImageManager.Instance.RequestImage(
            url,
            OnSuccess,
            OnFail,
            cacheInMemory
        );
    }

    private void OnSuccess(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(
            tex,
            new Rect(0, 0, tex.width, tex.height),
            new Vector2(0.5f, 0.5f)
        );

        img.sprite = sprite;
    }

    private void OnFail()
    {
        img.sprite = defaultSprite;
    }
}