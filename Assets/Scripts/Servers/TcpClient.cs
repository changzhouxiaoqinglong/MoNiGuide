﻿using Server.Constant;
using Server.Event;
using Server.Models.Net;
using Server.Servers;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Reflection;
using System;
namespace TcpServer.Servers
{
    /// <summary>
    /// 连接的客户端
    /// </summary>
    public class TcpClient
    {
        /// <summary>
        /// 客户端socket
        /// </summary>
        public Socket clientSocket;

        /// <summary>
        /// 服务器socket
        /// </summary>
        public TcpServer server;

        /// <summary>
        /// 接收处理
        /// </summary>
        private TcpReceiveHandler receiveHandler;

        /// <summary>
        /// 发送处理
        /// </summary>
        private TcpSendHandler sendHandler;

        /// <summary>
        /// 客户端心跳处理
        /// </summary>
        private TcpHeartBeat heartBeat;

        /// <summary>
        /// 用户数据
        /// </summary>
        public User user=new User() ;

        

        public TcpClient(Socket clientSocket, TcpServer server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
            receiveHandler = new TcpReceiveHandler(this);
            receiveHandler.StartReceive();
            sendHandler = new TcpSendHandler(this);
            heartBeat = new TcpHeartBeat(this);
            NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.HEART_BEAT, OnRevHeartBeat);
            //开始心跳计时
            heartBeat.StartRevTimer();
           // InitMsgHandleDic();
        }

       

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">发送的内容</param>
        /// <param name="protocolCode">协议号</param>
        public void SendMsg(string message, int protocolCode, int machineId = 0, int seatId = 0)
        {
            NetData data = new NetData()
            {
                Msg = message,
                ProtocolCode = protocolCode,
                MachineId = machineId,
                SeatId = seatId
            };
            SendMsg(data);
        }

        public void SendMsg(NetData data)
        {
            string sendStr = JsonTool.ToJson(data);
            if(data.ProtocolCode!=0)
           Logger.LogDebug("SendMsg:" + sendStr);
            if (data.ProtocolCode == 10671)
                Logger.LogDebug("转发deviceSendMsg:" + sendStr);
            // Logger.LogWarning("SendMsg ProtocolCode:" + data.ProtocolCode);
            sendHandler.AddSendMsg(TcpMessageHandler.PackMessage(sendStr));

        }

        public bool IsConnected()
        {
            return clientSocket != null && clientSocket.Connected;
        }

        /// <summary>
        /// 收到客户端传来的心跳包
        /// </summary>
        private void OnRevHeartBeat(IEventParam param)
        {
            //回发心跳包
            SendMsg("回发心跳包", NetProtocolCode.HEART_BEAT);
            heartBeat.ResetTimer();
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        public void DisConnect()
        {
            Logger.LogDebug("客户端断开连接");
            clientSocket.Close();
            server.ClientDisConnect(this);
            clientSocket.Dispose();
            //if (user != null)
            //{
            //    LoginManager.GetInstance().RemoveUser(user);
            //}
            NetEventDispatcher.GetInstance().RemoveTcpMsgEventListener(NetProtocolCode.HEART_BEAT, OnRevHeartBeat);
        }

        #region 接收客户端消息处理
        public  void OnRevMsg(NetData data)
        {
            if(data.ProtocolCode!=0)
            UnityEngine.Debug.Log("上面收到的是客户端的消息"+ data.ProtocolCode);
            //  base.OnRevMsg(data);
           

            //接收到消息 事件派发
            NetEventDispatcher.GetInstance().DispatchTcpMsgEvent(data.ProtocolCode, new TcpReceiveEvParam(data, this));
           
            //处理客户端消息转发
            HandleClientMsgForward(data);

        }

        /// <summary>
        /// 处理客户端消息的转发
        /// </summary>
        private void HandleClientMsgForward(NetData data)
        {
       
            //if (NetProtocolCode.IsNeedForwardClientToGuide(data.ProtocolCode))
            //{
            //    //转发消息
            //    //  NetManager.GetInstance().guideClient.SendMsg(data);//就是发给自己
              
            //}


   //         if(data.ProtocolCode==2)
			//{
   //             UnityEngine.Debug.Log("!!!!!!!!!!!!!!!!!" );
   //             LoginModel loginModel = JsonTool.ToObject<LoginModel>(data.Msg);
   //             LoginRes res = new LoginRes()
   //             {
   //                 UserName = loginModel.UserName,
   //             };
   //             SendMsg(JsonTool.ToJson(res), data.ProtocolCode, data.MachineId, data.SeatId);
   //         }
           

            if (user!=null&&user.initModel != null)
            {
                //客户端是三维软件
                if (user.initModel.EquipType == EquipType.UNITY)
                {
                    //需要转发
                    if (data.Forwards != null && data.Forwards.Count > 0)
                    {
                        foreach (var forward in data.Forwards)
                        {
                            server.SendMsgToClient(data, forward.MachineId, forward.SeatId);
                        }
                    }
                }
                //客户端是设备管理软件
                if (user.initModel.EquipType == EquipType.DEVICE)
                {
                    //需要转发设备管理软件消息 给 车上的三维软件
                    if (NetProtocolCode.IsNeedForwardDeviceToUnity(data.ProtocolCode))
                    {
                        //if (data.ProtocolCode == 10241)
                       //     Logger.LogWarning("遥测");
                        server.DeviceForwardUnity(data);
                    }
                }
            }
        }

        #endregion


       

      
        
    }
}
