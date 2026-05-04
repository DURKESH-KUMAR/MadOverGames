using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ImageCache
{
    private static Dictionary<string, Texture2D> memoryCache = new Dictionary<string, Texture2D>();

    private static string CachePath => Application.persistentDataPath + "/ImageCache/";
    private const float CACHE_EXPIRY_DAYS = 7f;

    public static void SaveToMemory(string url, Texture2D tex)
    {
        if (!memoryCache.ContainsKey(url))
            memoryCache.Add(url, tex);
    }

    public static Texture2D GetFromMemory(string url)
    {
        return memoryCache.ContainsKey(url) ? memoryCache[url] : null;
    }

    public static void SaveToDisk(string url, Texture2D tex)
    {
        if (!Directory.Exists(CachePath))
            Directory.CreateDirectory(CachePath);

        string path = GetFilePath(url);
        File.WriteAllBytes(path, tex.EncodeToPNG());
        File.WriteAllText(path + ".time", System.DateTime.Now.ToString());
    }

    public static Texture2D GetFromDisk(string url)
    {
        string path = GetFilePath(url);
        if (!File.Exists(path)) return null;

        string timePath = path + ".time";
        if (File.Exists(timePath))
        {
            System.DateTime saved = System.DateTime.Parse(File.ReadAllText(timePath));
            if ((System.DateTime.Now - saved).TotalDays > CACHE_EXPIRY_DAYS)
            {
                File.Delete(path);
                File.Delete(timePath);
                return null;
            }
        }

        byte[] bytes = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(bytes);
        return tex;
    }

    private static string GetFilePath(string url)
    {
        return CachePath + url.GetHashCode() + ".png";
    }
}