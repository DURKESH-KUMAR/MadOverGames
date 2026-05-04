using System;
using UnityEngine;

public class DownloadRequest
{
    public string Url;
    public Action<Texture2D> OnSuccess;
    public Action OnFail;
    public float RequestTime;
    public bool CacheInMemory;

    public DownloadRequest(string url, Action<Texture2D> onSuccess, Action onFail, bool cacheMemory)
    {
        Url = url;
        OnSuccess = onSuccess;
        OnFail = onFail;
        RequestTime = Time.time;
        CacheInMemory = cacheMemory;
    }
}
