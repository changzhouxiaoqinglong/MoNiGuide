

using System.IO;
using UnityEngine;

public class AppConstant
{
    /// <summary>
    /// 配置文件路径
    /// </summary>
    public static readonly string CONFIG_PATH = Path.Combine(Application.streamingAssetsPath, "Configs");

    /// <summary>
    /// 表文件路径
    /// </summary>
    public static readonly string EXCEL_PATH = Path.Combine(Application.streamingAssetsPath, "Excels");
}
