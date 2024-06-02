/// <summary>
/// 网络协议号
/// </summary>

using System.Collections.Generic;

public class NetProtocolCode
{
    #region tcp

    /// <summary>
    /// 心跳包
    /// </summary>
    public const int HEART_BEAT = 0;

    /// <summary>
    /// 初始数据
    /// </summary>
    public const int INIT_MSG = 1;

    /// <summary>
    /// 登录
    /// </summary>
    public const int LOGIN = 2;

    /// <summary>
    /// 下发任务环境
    /// </summary>
    public const int TASK_ENV = 4;

    /// <summary>
    /// 训练开始
    /// </summary>
    public const int TRAIN_START = 5;

    /// <summary>
    /// 操作毒剂报警器
    /// </summary>
    public const int POISON_ALARM_OP = 2011;

    /// <summary>
    /// 毒剂报警器 进样情况
    /// </summary>
    public const int POISON_IN_STATUS = 7;

    /// <summary>
    /// 温湿度风向风速下发
    /// </summary>
    public const int METEOR_ENV = 104;

    /// <summary>
    /// 结束训练
    /// </summary>
    public const int END = 9;

    /// <summary>
    /// 北斗数据  经纬度 时间
    /// </summary>
    public const int BEIDOU_DATA = 103;

    /// <summary>
    /// 操作辐射仪
    /// </summary>
    public const int RADIOME_OP = 2021;

    /// <summary>
    /// 设置辐射剂量率阈值
    /// </summary>
    public const int SET_RADIOM_RATE_THRESHOLD = 2022;

    /// <summary>
    /// 设置辐射 累计剂量率阈值
    /// </summary>
    public const int SET_TT_RADIOM_RATE_THRESHOLD = 2023;

    /// <summary>
    /// 发送辐射剂量率
    /// </summary>
    public const int SEND_RADIOM_RATE = 101;


    

    
    /// <summary>
    /// 操作电源
    /// </summary>
    public const int POWER_OP = 2041;

    /// <summary>
    /// 操作电台
    /// </summary>
    public const int RadioStation_OP = 2071;
    

    /// <summary>
    /// 操作北斗
    /// </summary>
    public const int BEIDOU_OP = 2051;

    /// <summary>
    /// 操作气象器件
    /// </summary>
    public const int METEOR_OP = 2052;

    /// <summary>
    /// 插旗子 通知导控
    /// </summary>
    public const int FLAG = 17;

    /// <summary>
    /// 操作车载侦毒器
    /// </summary>
    public const int OP_CAR_DETECT_POISON = 2032;

    /// <summary>
    /// 下车
    /// </summary>
    public const int OUT_CAR = 19;

    /// <summary>
    /// 下车结果
    /// </summary>
    public const int OUT_CAR_RES = 20;

    /// <summary>
    /// 上车
    /// </summary>
    public const int IN_CAR = 21;

    /// <summary>
    /// 上车结果
    /// </summary>
    public const int IN_CAR_RES = 22;

    /// <summary>
    /// 防护
    /// </summary>
    public const int PROTECT = 23;

    /// <summary>
    /// 插旗子 通知驾驶位 3D场景内插旗
    /// </summary>
    public const int FLAG_TO_DRIVER = 24;

    /// <summary>
    /// 设置抽气时间
    /// </summary>
    public const int SET_CAR_POIS_GAS_TIME = 2031;

    /// <summary>
    /// 成绩下发
    /// </summary>
    public const int GET_SCORE = 26;

    /// <summary>
    /// 车长命令
    /// </summary>
    public const int MASTER_INSTRUCT = 27;

    /// <summary>
    /// 导控控制训练进程
    /// </summary>
    public const int GUIDE_PROCESS_CTR = 33;

    #endregion
//------------------------------------

    //修改
    #region 102车协议

    /// <summary>
    /// 操作车载辐射仪
    /// </summary>
    public const int CAR_RADIOM_OP_102 = 10211;

    /// <summary>
    /// 设置辐射剂量率阈值 102
    /// </summary>
    public const int SET_RADIOM_RATE_THRESHOLD_102 = 10212;

    /// <summary>
    /// 设置辐射累计剂量率阈值 102
    /// </summary>
    public const int SET_TT_RADIOM_RATE_THRESHOLD_102 = 10213;

    /// <summary>
    /// 辐射仪当前累计剂量率
    /// </summary>
    public const int SET_TT_RADIOM_TOTAL_102 = 10214;

    /// <summary>
    /// 三防装置毒报
    /// </summary>
    public const int POIS_ALARM_102 = 10221;

    /// <summary>
    /// 三防装置差压计
    /// </summary>
    public const int DIFF_PRESSURE_102 = 10222;

    /// <summary>
    /// 三防上传压力值
    /// </summary>
    public const int PREVENT_DEVICE_PRESS_102 = 10223;

    /// <summary>
    /// 三防装置辐射仪
    /// </summary>
    public const int PREVENT_DEVICE_RADIOM_102 = 10224;

    /// <summary>
    /// 车载质谱仪
    /// </summary>
    public const int CAR_MASS_SPECT_102 = 10231;

    /// <summary>
    /// 车载质谱仪设置
    /// </summary>
    public const int CAR_MASS_SPECT_SET102 = 10232;

    /// <summary>
    /// 车载质谱仪压力
    /// </summary>
    public const int CAR_MASS_SPECT_PRESS_102 = 10233;

    /// <summary>
    /// 红外遥测模拟器
    /// </summary>
    public const int INFARED_TELEMETRY_102 = 10241;

    /// <summary>
    /// 红外遥测模拟器 参数
    /// </summary>
    public const int INFARED_TELEMETRY_PARAM_102 = 10242;

    /// <summary>
    /// 电源模拟器
    /// </summary>
    public const int POWER_102 = 10251;

    /// <summary>
    /// 操作电台
    /// </summary>
    public const int RadioStation_OP_102 = 10271;

    /// <summary>
    /// 气象器件
    /// </summary>
    public const int METEOR_102 = 10261;

    /// <summary>
    /// 车内温湿度
    /// </summary>
    public const int CAR_WET_TEM = 10262;

    
    #endregion

    #region 384车协议
    /// <summary>
    /// 操作DFH辐射仪
    /// </summary>
    public const int RADIOME_OP_384 = 38411;

    /// <summary>
    /// 设置辐射剂量率阈值
    /// </summary>
    public const int SET_RADIOM_RATE_THRESHOLD_384 = 38412;

    /// <summary>
    /// 设置辐射 累计剂量率阈值
    /// </summary>
    public const int SET_TT_RADIOM_RATE_THRESHOLD_384 = 38413;

    /// <summary>
    /// 操作毒剂报警器384
    /// </summary>
    public const int POISON_ALARM_OP_384 = 38421;

    /// <summary>
    /// 车载毒报选择工作模式
    /// </summary>
    public const int POISON_ALARM_WORK_TYPE_384 = 38422;

    /// <summary>
    /// 操作电源
    /// </summary>
    public const int POWER_OP_384 = 38431;

    /// <summary>
    /// 操作电台
    /// </summary>
    public const int RadioStation_OP_384 = 38471;
    #endregion

    #region 106车协议
    /// <summary>
    /// 操作电源106
    /// </summary>
    public const int POWER_OP_106 = 10641;

    /// <summary>
    /// 操作DFH辐射仪
    /// </summary>
    public const int RADIOME_OP_106 = 10621;

    /// <summary>
    /// 设置辐射剂量率阈值
    /// </summary>
    public const int SET_RADIOM_RATE_THRESHOLD_106 = 10622;

    /// <summary>
    /// 设置辐射 累计剂量率阈值
    /// </summary>
    public const int SET_TT_RADIOM_RATE_THRESHOLD_106 = 10623;

    public const int POISON_ALARM_OP_106 = 10611;

    public const int Biology_OP_106 = 10631;

    /// <summary>
    /// 设置生物模拟器数据
    /// </summary>
    public const int SET_Biology_RATE_THRESHOLD_106 = 10632;

    /// <summary>
    /// 106毒剂报警器训练流程  可控状态设置
    /// </summary>
    public const int POISON_ALARM_STAT_CTR_106 = 10612;

    /// <summary>
    /// 106操作电台
    /// </summary>
    public const int RadioStation_OP_106 = 10671;

    /// <summary>
    /// 设置减压阀数据
    /// </summary>
    public const int SET_SetReliefThreshold = 10681;

    #endregion

    #region 客户端的消息转发给导控
    /// <summary>
    /// 需要转发客户端消息给导控的协议
    /// </summary>
    public static readonly List<int> NEED_FORWARD_CLIENT_TO_GUIDE = new List<int>()
        {
            //登录
            LOGIN,
            //操作毒剂报警器
            POISON_ALARM_OP,
            //结束训练
            END,
            //操作辐射仪
            RADIOME_OP,
            //操作电源
            POWER_OP,
            //操作北斗
            BEIDOU_OP,
            //操作气象
            METEOR_OP,
            //操作车载侦毒器
            OP_CAR_DETECT_POISON,
            //设置剂量率和累计剂量率阈值
            SET_RADIOM_RATE_THRESHOLD,
            SET_TT_RADIOM_RATE_THRESHOLD,
            //插旗子
            FLAG,
            //进样状态
            POISON_IN_STATUS,
            //设置抽气时间
            SET_CAR_POIS_GAS_TIME,
            CAR_RADIOM_OP_102,
            SET_RADIOM_RATE_THRESHOLD_102,
            SET_TT_RADIOM_RATE_THRESHOLD_102,
            SET_TT_RADIOM_TOTAL_102,
            POIS_ALARM_102,
            DIFF_PRESSURE_102,
            PREVENT_DEVICE_PRESS_102,
            PREVENT_DEVICE_RADIOM_102,
            CAR_MASS_SPECT_102,
            CAR_MASS_SPECT_SET102,
            CAR_MASS_SPECT_PRESS_102,
            INFARED_TELEMETRY_102,
            INFARED_TELEMETRY_PARAM_102,
            POWER_102,
            METEOR_102,
            CAR_WET_TEM,
            RADIOME_OP_384,
            SET_RADIOM_RATE_THRESHOLD_384,
            SET_TT_RADIOM_RATE_THRESHOLD_384,
            POISON_ALARM_OP_384,
            POISON_ALARM_WORK_TYPE_384,
            POWER_OP_384,
        };

    /// <summary>
    /// 是否需要转发给导控
    /// </summary>
    public static bool IsNeedForwardClientToGuide(int protocolCode)
    {
        return NEED_FORWARD_CLIENT_TO_GUIDE.Contains(protocolCode);
    }
    #endregion

    #region 三维客户端消息 转发 给车上的设备管理软件

    /// <summary>
    /// 需要转发三维客户端消息 给 设备管理软件的协议
    /// </summary>
    public static readonly List<int> NEED_FORWARD_UNITY_TO_DEVICE = new List<int>()
        {
            //结束训练
            END,
            //设置剂量率
            SEND_RADIOM_RATE,

           
        };

    /// <summary>
    /// 是否需要转发三维消息 给 设备管理软件
    /// </summary>
    public static bool IsNeedForwardUnityToDevice(int protocolCode)
    {
        return NEED_FORWARD_UNITY_TO_DEVICE.Contains(protocolCode);
    }

    #endregion

    #region 设备管理软件消息 转发 给车上的三维客户端

    /// <summary>
    /// 需要转发设备管理软件 给 三维客户端消息的协议
    /// </summary>
    public static readonly List<int> NEED_FORWARD_DEVICE_TO_UNITY = new List<int>()
        {
            //操作02b毒剂报警器
            POISON_ALARM_OP,//2011
            //操作02b辐射仪
            RADIOME_OP,//2021
            //操作电源
            POWER_OP,//2041
              //操作电台
            RadioStation_OP,//2071
            //操作北斗
            BEIDOU_OP,//2051
            //操作气象
            METEOR_OP,//2052
            //操作车载侦毒器
            OP_CAR_DETECT_POISON,//2032
            //进样状态
            POISON_IN_STATUS,//7
            SET_RADIOM_RATE_THRESHOLD,//2022
            SET_TT_RADIOM_RATE_THRESHOLD,//2023
            SET_CAR_POIS_GAS_TIME,//2031
            CAR_RADIOM_OP_102,//10211
            SET_RADIOM_RATE_THRESHOLD_102,//10212
            SET_TT_RADIOM_TOTAL_102,//10214
            SET_TT_RADIOM_RATE_THRESHOLD_102,//10213
            POIS_ALARM_102,//10221
            PREVENT_DEVICE_PRESS_102,//10223
            DIFF_PRESSURE_102,//10222
            PREVENT_DEVICE_RADIOM_102,//10224
            CAR_MASS_SPECT_102,//10231
            CAR_MASS_SPECT_SET102,//10232
            CAR_MASS_SPECT_PRESS_102,//10233
            INFARED_TELEMETRY_102,//10241
            INFARED_TELEMETRY_PARAM_102,//10242
            POWER_102,//10251
            RadioStation_OP_102,//10271
            METEOR_102,//10261
            CAR_WET_TEM,//10262
            RADIOME_OP_384,//38411
            SET_RADIOM_RATE_THRESHOLD_384,//38412
            SET_TT_RADIOM_RATE_THRESHOLD_384,//38413
            POISON_ALARM_OP_384,//38421
            POISON_ALARM_WORK_TYPE_384,//38422
            POWER_OP_384,//38431
            RadioStation_OP_384,//38471
            POWER_OP_106,//10641
            RadioStation_OP_106,//10671
            SET_SetReliefThreshold,//10681
            RADIOME_OP_106,//10621
            SET_RADIOM_RATE_THRESHOLD_106,//10622
            SET_TT_RADIOM_RATE_THRESHOLD_106,//10623
            POISON_ALARM_OP_106,//10611
            Biology_OP_106,//10631
            SET_Biology_RATE_THRESHOLD_106,//10632
            POISON_ALARM_STAT_CTR_106,   //10612
           
        };

    /// <summary>
    /// 是否需要转发设备管理软件消息 给 三维客户端
    /// </summary>
    public static bool IsNeedForwardDeviceToUnity(int protocolCode)
    {
        return NEED_FORWARD_DEVICE_TO_UNITY.Contains(protocolCode);
    }

    #endregion

    #region 三维客户端的消息 转发 给车上其他的三维客户端
    /// <summary>
    /// 需要转发三维客户端 给 车上其他三维客户端消息的协议
    /// </summary>
    public static readonly List<int> NEED_FORWARD_UNITY_TO_UNITY = new List<int>()
        {
            //结束训练
            END,
            //插旗子
            FLAG_TO_DRIVER,
            //下车
            OUT_CAR,
            //下车结果
            OUT_CAR_RES,
            //上车
            IN_CAR,
            //上车结果
            IN_CAR_RES,
            //防护
            PROTECT,
        };

    /// <summary>
    /// 是否需要转发三维客户端消息 给 车上其他三维客户端
    /// </summary>
    public static bool IsNeedForwardUnityToUnity(int protocolCode)
    {
        return NEED_FORWARD_UNITY_TO_UNITY.Contains(protocolCode);
    }

    #endregion

    #region 导控下发的消息 需要 转发给设备管理软件
    /// <summary>
    /// 需要转发导控消息 给 车上设备管理软件
    /// </summary>
    public static readonly List<int> NEED_FORWARD_GUIDE_TO_DEVICE = new List<int>()
        {
            TASK_ENV,
        };

    /// <summary>
    /// 是否需要转发导控消息 给 车上设备管理软件
    /// </summary>
    public static bool IsNeedForwardGuideToDevice(int protocolCode)
    {
        return NEED_FORWARD_GUIDE_TO_DEVICE.Contains(protocolCode);
    }
    #endregion
}
