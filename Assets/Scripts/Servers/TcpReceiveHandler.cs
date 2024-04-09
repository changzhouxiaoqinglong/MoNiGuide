using Server.Constant;
using Server.Event;
using Server.Models;
using Server.Models.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpServer.Servers;
using TcpClient = TcpServer.Servers.TcpClient;

namespace Server.Servers
{
    public class TcpReceiveHandler
    {
        /// <summary>
        /// 存储处理接收到的数据
        /// </summary>
        private TcpMessageHandler message;

        private TcpClient client;

        public TcpReceiveHandler(TcpClient client)
        {
            this.client = client;
            message = new TcpMessageHandler(client);
        }

        /// <summary>
        /// 开始接收数据
        /// </summary>
        public void StartReceive()
        {
            if (client.clientSocket == null || client.clientSocket.Connected == false) return;

            client.clientSocket.BeginReceive(message.Datas, message.StartIndex, message.RemainSize, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult iar)
        {
            if (client.clientSocket == null || !client.clientSocket.Connected)
            {
                return;
            }
            //Logger.LogDebug("收到数据");
            try
            {
                //接收到的数据长度
                int length = client.clientSocket.EndReceive(iar);
                if (length > 0)
                {
                    try
                    {
                        message.AddReceiveNum(length);
                        //解析数据
                        message.ReadMessage();
                    }
                    catch (Exception e)
                    {
                        Logger.LogDebug("处理接收数据 异常:" + e.ToString());
                    }
                    StartReceive();
                }
                else
                {
                    Logger.LogDebug("接收客户端数据为空");
                    client.DisConnect();
                }
            }
            catch (Exception e)
            {
                Logger.LogDebug("接收客户端数据异常" + e.ToString());
                client.DisConnect();
            }

        }
    }
}
