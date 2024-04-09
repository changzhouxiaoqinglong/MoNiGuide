using Server.Constant;
using UnityEngine;

public class AppMain : MonoBehaviour
{
    private void Awake()
    {      
            InitConfig();
    }

    // Start is called before the first frame update
    void Start()
    {
        NetManager.GetInstance().Init();
    }

    private void InitConfig()
    {
        NetConfig.InitConfig();
        TaskDataMgr.GetInstance();
    }
}
