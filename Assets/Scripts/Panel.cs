
using Server.Constant;
using Server.Models.Net;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    /// <summary>
    /// 暂停
    /// </summary>
    public ButtonBase pauseBtn;

    /// <summary>
    /// 继续
    /// </summary>
    public ButtonBase continueBtn;

    /// <summary>
    /// 结束
    /// </summary>
    public ButtonBase EndBtn;

    public ButtonBase taskBtn;
    public GameObject taskPanel;

    public ButtonBase scoreBtn;
    private void Awake()
    {
        taskBtn.RegistClick(OnClickTask);
        scoreBtn.RegistClick(OnClickScore);

        pauseBtn.RegistClick(OnClickPause);
        continueBtn.RegistClick(OnClickContinue);
        EndBtn.RegistClick(OnClickEnd);
    }


    private void OnClickPause(GameObject obj)
    {
        GuideProcessCtrModel model = new GuideProcessCtrModel()
        {
            Operate = GuideProcessType.Pause,
        };
        NetManager.GetInstance().server.SendMsgToAll(JsonTool.ToJson(model), NetProtocolCode.GUIDE_PROCESS_CTR);
    }

    private void OnClickContinue(GameObject obj)
    {
        GuideProcessCtrModel model = new GuideProcessCtrModel()
        {
            Operate = GuideProcessType.Continue,
        };
        NetManager.GetInstance().server.SendMsgToAll(JsonTool.ToJson(model), NetProtocolCode.GUIDE_PROCESS_CTR);
    }

    private void OnClickEnd(GameObject obj)
    {
        GuideProcessCtrModel model = new GuideProcessCtrModel()
        {
            Operate = GuideProcessType.End,
        };
        NetManager.GetInstance().server.SendMsgToAll(JsonTool.ToJson(model), NetProtocolCode.GUIDE_PROCESS_CTR);
    }

    /// <summary>
    /// 点击下发任务按钮
    /// </summary>
    private void OnClickTask(GameObject obj)
    {
        taskPanel.SetActive(true);
    }

    /// <summary>
    /// 点击下发成绩按钮
    /// </summary>
    private void OnClickScore(GameObject obj)
    {
        //构建成绩
        GetScoreModel model = new GetScoreModel();
        model.Score = 80;
        List<DeductItem> itemList = new List<DeductItem>();
        itemList.Add(new DeductItem()
        {
            DeductScore = 5,
            Desc = "车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务车长未推送自检任务",
        });
        itemList.Add(new DeductItem()
        {
            DeductScore = 5,
            Desc = "电源未开机",
        });
        itemList.Add(new DeductItem()
        {
            DeductScore = 5,
            Desc = "CF未开机",
        });
        itemList.Add(new DeductItem()
        {
            DeductScore = 5,
            Desc = "2号未投标志旗",
        });
        model.DeductItems = itemList;
        NetManager.GetInstance().server.SendMsgToAll(JsonTool.ToJson(model), NetProtocolCode.GET_SCORE);
    }
}
