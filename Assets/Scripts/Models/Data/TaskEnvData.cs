using System.Collections.Generic;
/// <summary>
/// 有害元素
/// </summary>
public class HarmData
{
    public enum HarmTypeEnum
    {
        /// <summary>
        /// 毒剂
        /// </summary>
        Drug = 1,

        /// <summary>
        /// 辐射
        /// </summary>
        Radiate,
    }

    /// <summary>
    /// 类型
    /// </summary>
    public int HarmType;

    /// <summary>
    /// 具体内容
    /// </summary>
    public string Content;
}

public class TaskEnvData
{

    /// <summary>
    /// 训练id（用于多人训练）
    /// </summary>
    public int TrainId;

    /// <summary>
    /// 模式 0.单机  1.考核  2.训练
    /// </summary>
    public int CheckType;

    /// <summary>
    /// 任务编号
    /// </summary>
    public int TaskId;

    /// <summary>
    /// 场景
    /// </summary>
    public int Scene;

    /// <summary>
    /// 天气
    /// </summary>
    public int Weather;

    /// <summary>
    /// 风向
    /// </summary>
    public int WindDir;

    /// <summary>
    /// 风速
    /// </summary>
    public int WindSp;

    /// <summary>
    /// 温度
    /// </summary>
    public int Temperate;

    /// <summary>
    /// 湿度
    /// </summary>
    public int Humidity;

    /// <summary>
    /// 车型编号
    /// </summary>
    public int CarId;

    public string Time;

    /// <summary>
    /// 车辆位置
    /// </summary>
    public CustVect3 CardPos;

    /// <summary>
    /// 有害元素信息
    /// </summary>
    public List<HarmData> HarmDatas = new List<HarmData>();

    /// <summary>
    /// 弹坑数据
    /// </summary>
    public List<CraterVarData> CraterDatas = new List<CraterVarData>();

    public Wearth Wearth;
}

/// <summary>
/// 天气数据
/// </summary>
public class Wearth
{
    /// <summary>
    /// 天气类型
    /// </summary>
    public int Type;

    /// <summary>
    /// 风向
    /// </summary>
    public int WindDir;

    /// <summary>
    /// 风速
    /// </summary>
    public int WindSp;

    /// <summary>
    /// 温度
    /// </summary>
    public float Temperate;

    /// <summary>
    /// 湿度
    /// </summary>
    public float Humidity;
}

/// <summary>
/// 弹坑数据
/// </summary>
public class CraterVarData
{
    public int Id;

    /// <summary>
    /// 位置
    /// </summary>
    public CustVect3 Pos;

    /// <summary>
    /// 毒剂类型
    /// </summary>
    public int Type;

    /// <summary>
    /// 浓度
    /// </summary>
    public float Dentity;
}
