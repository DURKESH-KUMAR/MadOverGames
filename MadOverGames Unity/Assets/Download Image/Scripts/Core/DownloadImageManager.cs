using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadImageManager : MonoBehaviour
{
    public static DownloadImageManager Instance;

    private Queue<DownloadRequest> queue = new Queue<DownloadRequest>();
    private int activeDownloads = 0;

    private const int MAX_DOWNLOADS = 3;
    private const float MAX_WAIT = 10f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        ProcessQueue();
    }

    public void RequestImage(string url, System.Action<Texture2D> onSuccess, System.Action onFail, bool cacheMemory)
    {
        Texture2D mem = ImageCache.GetFromMemory(url);
        if (mem != null)
        {
            onSuccess?.Invoke(mem);
            return;
        }

        Texture2D disk = ImageCache.GetFromDisk(url);
        if (disk != null)
        {
            if (cacheMemory) ImageCache.SaveToMemory(url, disk);
            onSuccess?.Invoke(disk);
            return;
        }

        queue.Enqueue(new DownloadRequest(url, onSuccess, onFail, cacheMemory));
    }

    private void ProcessQueue()
    {
        if (queue.Count == 0) return;

        DownloadRequest req = queue.Peek();
        bool timeout = Time.time - req.RequestTime > MAX_WAIT;

        if (activeDownloads < MAX_DOWNLOADS || timeout)
        {
            queue.Dequeue();
            StartCoroutine(Download(req));
        }
    }

    private IEnumerator Download(DownloadRequest req)
    {
        activeDownloads++;

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(req.Url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Texture2D tex = DownloadHandlerTexture.GetContent(www);

            ImageCache.SaveToDisk(req.Url, tex);
            if (req.CacheInMemory)
                ImageCache.SaveToMemory(req.Url, tex);

            req.OnSuccess?.Invoke(tex);
        }
        else
        {
            req.OnFail?.Invoke();
        }

        activeDownloads--;
    }
}
