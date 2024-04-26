using Server.Constant;
using Server.Models.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static HarmData;
using static UnityEngine.UI.Dropdown;

public class TaskPanel : MonoBehaviour
{
    public ButtonBase closeBtn;

    /// <summary>
    /// 任务下拉菜单
    /// </summary>
    public Dropdown taskDropDown;

    /// <summary>
    /// 场景下拉菜单
    /// </summary>
    public Dropdown sceneDropDown;

    /// <summary>
    /// 天气下拉菜单
    /// </summary>
    public Dropdown weatherDropDown;
    #region 毒
    /// <summary>
    /// 毒编号
    /// </summary>
    public InputField drugId;

    /// <summary>
    /// 毒类型
    /// </summary>
    public InputField drugType;

    public InputField drugPos;

    public InputField drugRange;

    public InputField drugDentity;

    public InputField drugSpeed;

    public ButtonBase addDrugBtn;

    /// <summary>
    /// 待下发的毒数据
    /// </summary>
    private List<DrugVarData> drugDatas = new List<DrugVarData>();
    #endregion

    #region 辐射
    /// <summary>
    /// 辐射弹坑编号
    /// </summary>
    public InputField fuSheId;

    /// <summary>
    /// 辐射弹坑位置
    /// </summary>
    public InputField fuShePos;

    public InputField fuSheRange;

    public InputField fuSheRate;

    public InputField fuSheTotalRate;

    public ButtonBase addFusheBtn;

    /// <summary>
    /// 待下发的辐射数据
    /// </summary>
    private List<FuSheVarData> fuSheDatas = new List<FuSheVarData>();
    #endregion

    #region 弹坑
    public InputField craterId;

    public InputField craterPos;

    public ButtonBase craterAdd;

    public InputField craterDrugType;

    public InputField craterDentityType;
    /// <summary>
    /// 待下发弹坑数据
    /// </summary>
    public List<CraterVarData> CraterDatas = new List<CraterVarData>();

    #endregion
    public InputField winDir;

    public InputField winSp;

    public InputField temperate;

    public InputField wet;

    public ButtonBase okBtn;

    public InputField carPos;

    /// <summary>
    /// 训练id 用于多车共同训练
    /// </summary>
    public InputField trainId;

    /// <summary>
    /// 开始训练按钮
    /// </summary>
    public ButtonBase startTrainBtn;

    /// <summary>
    /// 模式下拉框
    /// </summary>
    public Dropdown modeDropDown;

    void Awake()
    {
        closeBtn.RegistClick(OnClickClose);
        addDrugBtn.RegistClick(OnClickAddDrug);
        addFusheBtn.RegistClick(OnClickAddFushe);
        craterAdd.RegistClick(OnClickAddCrater);
        okBtn.RegistClick(OnClickOkBtn);
        startTrainBtn.RegistClick(OnClickStartTrain);
    }

    private void Start()
    {
        InitTaskDropDown();
        InitSceneDropDown();
        InitWeatherDropDown();
        sceneDropDown.onValueChanged.AddListener(OnSceneChaneged);

        return;
        carPos.text = "29.15237,88.64471,0";
        fuShePos.text = "29.15584,88.64548,0";
        drugPos.text = "29.15997,88.65074,0";
        craterPos.text = "29.16168,88.65231,0";
    }

    void OnSceneChaneged(int index)
	{
		switch(index)
		{
            case 0:
                carPos.text = "29.15237,88.64471,0";
                fuShePos.text = "29.15584,88.64548,0";
                drugPos.text = "29.15997,88.65074,0";
                craterPos.text = "29.16168,88.65231,0";
                break;

            case 1:
                carPos.text = "35.56856,114.3004,0";
                fuShePos.text = "35.56771,114.3015,0";
                drugPos.text = "35.56777,114.2996,0";
                craterPos.text = "35.56745,114.2933,0";
                break;
            case 2:
                carPos.text = "23.59842,106.633,0";
                fuShePos.text = "23.59421,106.6283,0";
                drugPos.text = "23.59421,106.6194,0";
                craterPos.text = "23.59182,106.6194,0";
                break;
            case 3:
                carPos.text = "29.88665,93.59372,0";
                fuShePos.text = "29.88556,93.59334,0";
                drugPos.text = "29.88556,93.59446,0";
                craterPos.text = "29.88681,93.59628,0";
                break;
            case 4:
                carPos.text = "0,0,0";
                fuShePos.text = "0,0,0";
                drugPos.text = "0,0,0";
                craterPos.text = "0,0,0";
                break;
            case 5:
                carPos.text = "0,0,0";
                fuShePos.text = "0,0,0";
                drugPos.text = "0,0,0";
                craterPos.text = "0,0,0";
                break;
            case 6:
                carPos.text = "0,0,0";
                fuShePos.text = "0,0,0";
                drugPos.text = "0,0,0";
                craterPos.text = "0,0,0";
                break;
        }
	}

    private void OnEnable()
    {
        taskDropDown.value = 0;
        sceneDropDown.value = 0;
        modeDropDown.value = 0;
    }

    void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnClickAddDrug(GameObject obj)
    {
        string[] poses = drugPos.text.Split(',');
        DrugVarData drugData = new DrugVarData()
        {
            Id = drugId.text.ToInt(),
            Type = drugType.text.ToInt(),
            Pos = new CustVect3(poses[0].ToFloat(), poses[1].ToFloat(), poses[2].ToFloat()),
            Range = drugRange.text.ToInt(),
            Dentity = drugDentity.text.ToInt(),
            Speed = drugSpeed.text.ToInt(),
        };
        drugDatas.Add(drugData);
    }

    private void OnClickAddFushe(GameObject obj)
    {
        string[] poses = fuShePos.text.Split(',');
        FuSheVarData fusheData = new FuSheVarData()
        {
            Id = fuSheId.text.ToInt(),
            Pos = new CustVect3(poses[0].ToFloat(), poses[1].ToFloat(), poses[2].ToFloat()),
            Range = fuSheRange.text.ToInt(),
            DoseRate = fuSheRate.text.ToInt(),
            DangLiang = fuSheTotalRate.text.ToInt(),
        };
        fuSheDatas.Add(fusheData);
    }

    private void OnClickAddCrater(GameObject obj)
    {
        string[] poses = craterPos.text.Split(',');
        CraterVarData craterData = new CraterVarData()
        {
            Id = craterId.text.ToInt(),
            Pos = new CustVect3(poses[0].ToFloat(), poses[1].ToFloat(), poses[2].ToFloat()),
            Type = craterDrugType.text.ToInt(),
            Dentity = craterDentityType.text.ToFloat(),
        };
        CraterDatas.Add(craterData);
    }

    private void InitTaskDropDown()
    {
        taskDropDown.options.Clear();
        foreach (var item in TaskDataMgr.GetInstance().dataList)
        {
            OptionData option = new OptionData(item.Desc);
            taskDropDown.options.Add(option);
        }
        taskDropDown.RefreshShownValue();
    }
    private void InitSceneDropDown()
    {
        sceneDropDown.options.Clear();
        foreach (var item in SceneDataMgr.GetInstance().dataList)
        {
            OptionData option = new OptionData(item.Desc);
            sceneDropDown.options.Add(option);
        }
        sceneDropDown.RefreshShownValue();
    }
    private void InitWeatherDropDown()
    {
        weatherDropDown.options.Clear();
        foreach (var item in WeatherDataMgr.GetInstance().dataList)
        {
            OptionData option = new OptionData(item.Desc);
            weatherDropDown.options.Add(option);
        }
        weatherDropDown.RefreshShownValue();
    }

    private void OnClickOkBtn(GameObject obj)
    {
        string[] carPoses = carPos.text.Split(',');
        CustVect3 carVect = new CustVect3(carPoses[0].ToFloat(), carPoses[1].ToFloat(), carPoses[2].ToFloat());
        //下发数据
        TaskEnvData taskEnvData = new TaskEnvData()
        {
            TaskId = TaskDataMgr.GetInstance().dataList[taskDropDown.value].Id,
            Scene = SceneDataMgr.GetInstance().dataList[sceneDropDown.value].Id,
          //  Weather = WeatherDataMgr.GetInstance().dataList[weatherDropDown.value].Id,
           // WindDir = winDir.text.ToInt(),
           // WindSp = winSp.text.ToInt(),
           // Temperate = temperate.text.ToInt(),
          //  Humidity = wet.text.ToInt(),
            //CardPos = carVect,
            TrainId = trainId.text.ToInt(),
            CheckType = modeDropDown.value,
            Time = DateTime.Now.ToString("yyyyMMddHHmmss"),
            Wearth = new Wearth() 
            { 
            Type= WeatherDataMgr.GetInstance().dataList[weatherDropDown.value].Id,
                WindDir = winDir.text.ToInt(),
                WindSp = winSp.text.ToInt(),
                Temperate = temperate.text.ToInt(),
                Humidity = wet.text.ToInt(),
            },
        };
        //print(SceneDataMgr.GetInstance().dataList[sceneDropDown.value].Id);
        print(WeatherDataMgr.GetInstance().dataList[weatherDropDown.value].Id);
        foreach (var item in drugDatas)
        {
            HarmData harmData = new HarmData();
            harmData.HarmType = Convert.ToInt32(HarmTypeEnum.Drug);
            harmData.Content = JsonTool.ToJson(item);
            taskEnvData.HarmDatas.Add(harmData);
        }
        print(drugDatas.Count);
        foreach (var item in fuSheDatas)
        {
            HarmData harmData = new HarmData();
            harmData.HarmType = Convert.ToInt32(HarmTypeEnum.Radiate);
            harmData.Content = JsonTool.ToJson(item);
            taskEnvData.HarmDatas.Add(harmData);
        }
        print(fuSheDatas.Count);
        print(CraterDatas.Count);
        taskEnvData.CraterDatas = CraterDatas;
        NetManager.GetInstance().server.SendMsgToAll(JsonTool.ToJson(taskEnvData), NetProtocolCode.TASK_ENV);
    }

    private void OnClickStartTrain(GameObject obj)
    {

    string[] carPoses = carPos.text.Split(',');
        CustVect3 carVect = new CustVect3(carPoses[0].ToFloat(), carPoses[1].ToFloat(), carPoses[2].ToFloat());

        //所有车数据
        List<TrainMachineData> trainMachineDatas = new List<TrainMachineData>();
        foreach (var item in NetManager.GetInstance().server.machineUsers)
        {
            //车数据
            TrainMachineData trainMachineData = new TrainMachineData()
            {
                MachineId = item.Key,
                InitPos = carVect,
                CarId = item.Value[0].CarId,//device carid是0 所以不能先启动
            };
            //生成该机号对应的人数据
            foreach (var user in item.Value)
            {
                TrainSeatData userData = new TrainSeatData()
                {
                    SeatId = user.SeatId,
                    MachineId = user.MachineId,
                };
                trainMachineData.TrainUserData.Add(userData);
            }
            trainMachineDatas.Add(trainMachineData);
        }
        //构建数据
        StartTrainModel startTrain = new StartTrainModel()
        {
            TrainMachineDatas = trainMachineDatas
        };
        NetManager.GetInstance().server.SendMsgToAll(JsonTool.ToJson(startTrain), NetProtocolCode.TRAIN_START);
    }

    private void OnDisable()
    {
        drugDatas.Clear();
        fuSheDatas.Clear();
    }
}