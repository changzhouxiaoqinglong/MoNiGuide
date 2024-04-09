using System;
using System.Collections.Generic;
using System.Net.Sockets;
using TcpServer.Servers;

namespace Server.Servers
{
    public class TcpSendHandler
    {
        /// <summary>
        /// 待发送消息
        /// </summary>
        private Queue<byte[]> sendMessages = new Queue<byte[]>();

        private TcpServer.Servers.TcpClient client;

        /// <summary>
        /// 是否正在发送消息
        /// </summary>
        private bool isSending = false;

        public TcpSendHandler(TcpServer.Servers.TcpClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// 添加发送消息
        /// </summary>
        public void AddSendMsg(byte[] message)
        {
            sendMessages.Enqueue(message);
            CheckDoSendMsg();
        }

        /// <summary>
        /// 检测发送消息
        /// </summary>
        private void CheckDoSendMsg()
        {
            if (client.clientSocket == null || !client.clientSocket.Connected)
            {
                Logger.LogDebug("客户端没连接 无法发送消息");
                Reset();
                return;
            }
            if (isSending || sendMessages.Count <= 0)
            {
                return;
            }
            isSending = true;
            try
            {
                byte[] data = sendMessages.Dequeue();
                client.clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallBack, null);
            }
            catch (System.Exception e)
            {
                isSending = false;
                Logger.LogDebug("向客户端发送消息异常" + e.ToString());
            }
        }

        private void SendCallBack(IAsyncResult iar)
        {
            client.clientSocket.EndSend(iar);
            isSending = false;
            CheckDoSendMsg();
        }

        public void Reset()
        {
            sendMessages.Clear();
        }
    }
}
