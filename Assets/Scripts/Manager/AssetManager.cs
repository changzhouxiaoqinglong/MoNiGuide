
using System.IO;
using UnityEngine;

public class AssetManager
{
    /// <summary>
    /// 读取StreamingAssets下的文本文件
    /// </summary>
    /// <param name="path"></param>
    public static string ReadTextFromStreamAsset(string path)
    {
        path = Path.Combine(Application.streamingAssetsPath, path);

        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }

        return null;
    }
}
