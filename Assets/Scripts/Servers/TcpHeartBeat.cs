using Server.Constant;
using System;
using System.Collections.Generic;
using System.Threading;
using TcpServer.Servers;

namespace Server.Servers
{
    public class TcpHeartBeat
    {
        private TcpClient tcpClient;

        /// <summary>
        /// 接收心跳 间隔计时器
        /// </summary>
        private int revTimer = 0;

        /// <summary>
        /// 是否正在处理接收
        /// </summary>
        private bool isHandleReceive = false;

        public TcpHeartBeat(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }

        /// <summary>
        /// 重置计时
        /// </summary>
        public void ResetTimer()
        {
            revTimer = 0;
        }

        /// <summary>
        /// 开始处理接收计时  超时断开连接
        /// </summary>
        public void StartRevTimer()
        {
            if (!isHandleReceive)
            {
                new Thread(RevTimerHandle).Start();
            }
        }

        /// <summary>
        /// 接收计时 超时断开连接
        /// </summary>
        private void RevTimerHandle()
        {
            isHandleReceive = true;
            while (true)
            {
                Thread.Sleep(1000);
                //未连接
                if (!tcpClient.IsConnected())
                {
                    break;
                }
                revTimer += 1;
                if (revTimer >= NetConfig.HEART_BEAT_TIME_OUT)
                {
                    //断开连接
                    tcpClient.DisConnect();
                    Logger.LogDebug("客户端心跳超时 断开连接");
                    break;
                }
            }
            isHandleReceive = false;
            ResetTimer();
        }
    }
}
