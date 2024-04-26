

using System.Collections.Generic;
/// <summary>
/// 参与训练的车人数据
/// </summary>
public class TrainMachineData
{
    /// <summary>
    /// 机号
    /// </summary>
    public int MachineId;

    /// <summary>
    /// 车型
    /// </summary>
    public int CarId;

    /// <summary>
    /// 初始位置
    /// </summary>
    public CustVect3 InitPos;

    /// <summary>
    /// 该车参加训练的 席位数据
    /// </summary>
    public  List<TrainSeatData> TrainUserDatas = new List<TrainSeatData>();
}
