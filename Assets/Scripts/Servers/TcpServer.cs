using Server.Constant;
using Server.Event;
using Server.Models.Net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// 服务器
/// </summary>
namespace TcpServer.Servers
{
    public class TcpServer
    {
        /// <summary>
        /// 服务器地址和端口号
        /// </summary>
        public IPEndPoint ipEndPoint;

        /// <summary>
        /// 服务器socket
        /// </summary>
        private Socket serverSocket;

        /// <summary>
        /// 当前连接的客户端
        /// </summary>
       // private TcpClient client;

        /// <summary>
        /// 当前连接的客户端
        /// </summary>
        private List<TcpClient> clientList = new List<TcpClient>();



        /// <summary>
        /// 同机号用户
        /// </summary>
        public Dictionary<int, List<User>> machineUsers = new Dictionary<int, List<User>>();

        public TcpServer(string ipAddress, int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.LOGIN, OnRevLoginMsg);
            NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.INIT_MSG, OnInitMsg);
            //NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.EXIT_LOGIN, OnRevExit);
        }

        /// <summary>
        /// 开启服务器
        /// </summary>
        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(NetConfig.TCP_CONNECT_NUM);
            serverSocket.BeginAccept(AcceptCallBack, null);//开始异步接收数据
            Logger.LogDebug("服务器开启，开始异步接收数据");
        }

        private void AcceptCallBack(IAsyncResult iar)
        {
            Socket clientSocket = serverSocket.EndAccept(iar);
            TcpClient client = new TcpClient(clientSocket, this);
            //this.client = client;
            clientList.Add(client);
            Debug.Log("\\\\\\\\\\");
            Logger.LogDebug("客户端已连接");
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        public void ClientDisConnect(TcpClient client)
        {
            lock (this.clientList)
            {
                clientList.Remove(client);
                // Logger.LogDebug("有客户端断开连接：" + "当前客户端连接数量：" + clientList.Count);


                Logger.LogDebug("有客户端断开连接：");
                if (machineUsers.ContainsKey(client.user.MachineId))
                {
                    List<User> users = machineUsers[client.user.MachineId];
                    lock (users)
                    {
                        int length = users.Count;
                        for (int i = length - 1; i >= 0; i--)
                        {
                            if (users[i].SeatId == client.user.SeatId)
                            {
                                users.RemoveAt(i);
                            }
                        }
                    }
                }
                Debug.Log("用户退出 机号： " + client.user.MachineId + " 用户名：" + client.user.UserName +
                  "当前剩余登录总人数为：" + clientList.Count);
                int machineLeft = machineUsers.ContainsKey(client.user.MachineId) ? machineUsers[client.user.MachineId].Count : 0;
                Debug.Log("当前机器剩余登录人数为： " + machineLeft);

            }

        }

        /// <summary>
        /// 接收登录消息
        /// </summary>
        private void OnInitMsg(IEventParam param)
        {
            Debug.Log("收到init消息");
            if (param is TcpReceiveEvParam tcpParam && tcpParam.client is TcpClient client)
            {
                Debug.Log("收到init消息: " + tcpParam.netData.Msg);
                var initModel = JsonTool.ToObject<InitModel>(tcpParam.netData.Msg);
                client.user.initModel = JsonTool.ToObject<InitModel>(tcpParam.netData.Msg);
                Debug.Log(initModel.EquipType);
               
                client.user.MachineId = tcpParam.netData.MachineId;
                client.user.SeatId = tcpParam.netData.SeatId;
               
                lock (machineUsers)
                {
                    //根据机型 补充字典数据
                    int machineId = tcpParam.netData.MachineId;
                    if (machineUsers.ContainsKey(machineId))
                    {
                        machineUsers[machineId].Add(client.user);
                    }
                    else
                    {
                        List<User> userList = new List<User>();
                        userList.Add(client.user);
                        machineUsers[machineId] = userList;
                    }
                    Debug.Log("目前机号 " + machineId + "  当前机号下登录人数为：" + machineUsers[machineId].Count);
                }
             
            }
        }


        /// <summary>
        /// 接收登录消息
        /// </summary>
        private void OnRevLoginMsg(IEventParam param)
        {
            Debug.Log("收到登录消息");
            if (param is TcpReceiveEvParam tcpParam && tcpParam.client is TcpClient client)
            {
                LoginModel loginModel = JsonTool.ToObject<LoginModel>(tcpParam.netData.Msg);
                Debug.Log("收到登录消息: "+ tcpParam.netData.Msg);
                LoginRes res = new LoginRes()
                {
                    UserName = loginModel.UserName,
                };
                Debug.Log("登陆成功  用户名：" + loginModel.UserName + "   机号：" + tcpParam.netData.MachineId + "  席位号：" + tcpParam.netData.SeatId);

                client.user.UserName = loginModel.UserName;
                client.user.CarId = loginModel.CarId;
                // client.user.MachineId = tcpParam.netData.MachineId;
                //  client.user.SeatId = tcpParam.netData.SeatId;
                // client.user.initModel = new InitModel { EquipType = (tcpParam.netData.SeatId == 5) ? 2 : 1 };
                //User user = new User()
                //{
                //    UserName = loginModel.UserName,
                //    CarId = loginModel.CarId,
                //    MachineId = tcpParam.netData.MachineId,
                //    SeatId = tcpParam.netData.SeatId,

                //};

                //增加用户
                // client.user = user;

                //lock (machineUsers)
                //{
                //    //根据机型 补充字典数据
                //    int machineId = tcpParam.netData.MachineId;
                //    if (machineUsers.ContainsKey(machineId))
                //    {
                //        machineUsers[machineId].Add(client.user);
                //    }
                //    else
                //    {
                //        List<User> userList = new List<User>();
                //        userList.Add(client.user);
                //        machineUsers[machineId] = userList;
                //    }
                //    Debug.Log("目前机号 " + machineId + "  当前机号下登录人数为：" + machineUsers[machineId].Count);
                //}

                //登录成功 回发消息
                //  SendMsgToUser(JsonTool.ToJson(res), tcpParam.netData.ProtocolCode, tcpParam.netData.MachineId, tcpParam.netData.SeatId);
                client.SendMsg(JsonTool.ToJson(res), tcpParam.netData.ProtocolCode, tcpParam.netData.MachineId, tcpParam.netData.SeatId);
            }
        }


        /// <summary>
        /// 发送消息给具体人
        /// </summary>
        public void SendMsgToUser(string message, int protocolCode, int machineId, int seatId)
        {        
            GetClientByMachinSeat(machineId, seatId).SendMsg(message, protocolCode, machineId, seatId);
        }

        /// <summary>
        /// 发送消息给对应车的所有人
        /// </summary>
        public void SendMsgToCar(string message, int protocolCode, int machineId)
        {
            foreach (var _client in clientList)
            {
                if (_client.user.MachineId == machineId)
                {
                    _client.SendMsg(message, protocolCode);
                }
            }
        }

        /// <summary>
        /// 发送消息给所有人
        /// </summary>
        public void SendMsgToAll(string message, int protocolCode)
        {
            foreach (var _client in clientList)
            {
                _client.SendMsg(message, protocolCode);
            }
        }

        public void SendMsg(NetData netData)
        {
            //  client.SendMsg(netData);
        }

        public void Close()
        {
            //if (client != null)
            //{
            //    client.DisConnect();
            //}

            lock (this.clientList)
            {
                for (int i = 0; i < this.clientList.Count; i++)
                {
                    this.clientList[i].DisConnect();
                }
                this.clientList.Clear();
            }


            serverSocket.Close();
            serverSocket.Dispose();
        }


        /// <summary>
        /// 通过机号和席位号 找到对应的客户端
        /// </summary>
        private TcpClient GetClientByMachinSeat(int machineId, int seatId)
        {
            TcpClient res = null;

            foreach (var _client in clientList)
            {
                if (_client.user.SeatId == seatId && _client.user.MachineId == machineId)
                {
                    res = _client;
                }
            }
            if (res == null)
            {
                Debug.Log("没有找到对应的客户端 可能还没有上报初始数据  机号：" + machineId + "席位号：" + seatId);
            }
            return res;
        }


        #region
        //转发


        /// <summary>
        /// 发给客户端消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="MachineId">机号</param>
        /// <param name="SeatId">座位号</param>
        /// <param name="equipType">客户端类型-1.不限制  1.三维软件 2.设备管理软件</param>
        /// <param name="exceptClient">排除的client 不会向此client发送消息</param>
        public void SendMsgToClient(NetData data, int MachineId, int SeatId = 0, int equipType = -1, TcpClient exceptClient = null)
        {
            Debug.Log("SendMsgToClient");
            //要指定机号和席位号转发
            if (MachineId > 0)
            {
                if (SeatId > 0)
                {
                    //找到对应的客户端
                    TcpClient client = GetClientByMachinSeat(MachineId, SeatId);
                    if (client != exceptClient && (equipType == -1 || equipType == client.user.initModel.EquipType))
                    {
                        client.SendMsg(data);
                    }
                }
                else
                {                
                    //没给席位号  就转发消息给 对应条件的所有客户端
                    if (machineUsers.ContainsKey(MachineId))
                    {
                        foreach (var item in clientList)
                        {
                            if (item != exceptClient && (equipType == -1 || equipType == item.user.initModel.EquipType))
                            {
                                item.SendMsg(data);
                            }
                        }
                    }
                }
            }
        }





        /// <summary>
        /// 三维客户端消息转发给 车上的设备管理软件
        /// </summary>
        public void UnityForwardDevice(NetData data)
        {
            SendMsgToClient(data, data.MachineId, equipType: EquipType.DEVICE);
        }

        /// <summary>
        /// 设备管理软件消息转发给 车上的三维客户端
        /// </summary>
        public void DeviceForwardUnity(NetData data)
        {
            Debug.Log("设备管理软件消息转发给 车上的三维客户端");
            SendMsgToClient(data, data.MachineId, equipType: EquipType.UNITY);
        }

		/// <summary>
		/// 三维客户端消息  转发给车上其他客户端
		/// </summary>
		public void UnityForwardToUnity(NetData data, TcpClient client)
		{
			SendMsgToClient(data, data.MachineId, equipType: EquipType.UNITY, exceptClient: client);
		}

		#endregion

	}
}
