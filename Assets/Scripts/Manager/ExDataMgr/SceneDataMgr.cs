using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataMgr : ExDataMgrBase<SceneDataMgr, ExSceneData>
{
    /// <summary>
    /// 表名
    /// </summary>
    protected override string FILE_NAME { get; set; } = "SceneData.txt";
}
