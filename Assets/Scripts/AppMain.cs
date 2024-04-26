using Server.Constant;
using UnityEngine;
using System;
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
    
  //   foreach(var a in BitConverter.GetBytes(0x352EF853))
		//{
  //          print(a);
		//}
    }

    private void InitConfig()
    {
        NetConfig.InitConfig();
        TaskDataMgr.GetInstance();
    }
}
