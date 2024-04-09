using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherDataMgr: ExDataMgrBase<WeatherDataMgr, ExWeatherData>
{
    /// <summary>
    /// 表名
    /// </summary>
    protected override string FILE_NAME { get; set; } = "WeatherData.txt";
}
