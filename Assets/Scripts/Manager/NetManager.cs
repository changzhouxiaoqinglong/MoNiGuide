
using Server.Constant;
using UnityEngine;

public class NetManager : MonoSingleTon<NetManager>
{
    //当前服务器
    public TcpServer.Servers.TcpServer server;

    public void Init()
    {
        //开启服务器
        StartServer();
    }

    /// <summary>
    /// 开启服务器
    /// </summary>
    public void StartServer()
    {
        string ip = NetConfig.IP;
        int port = NetConfig.PORT;
        server = new TcpServer.Servers.TcpServer(ip, port);
        server.Start();
    }

    private void OnDestroy()
    {
        server.Close();
    }

	private void Update()
	{
        

    }
}
