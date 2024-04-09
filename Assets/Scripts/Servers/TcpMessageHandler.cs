using Server.Constant;
using Server.Event;
using Server.Models.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer.Servers
{
    public class TcpMessageHandler
    {
        private TcpClient tcpClient;

        /// <summary>
        /// 用于存储接收到的数据
        /// </summary>
        private byte[] datas = new byte[51200];

        public byte[] Datas
        {
            get { return datas; }
        }

        /// <summary>
        /// 当前存储数据 开始接收的位置（也就是当前收到数据的尾部）
        /// </summary>
        private int startIndex = 0;

        public int StartIndex { get { return startIndex; } }

        /// <summary>
        /// 剩余能接收的大小
        /// </summary>
        public int RemainSize
        {
            get { return datas.Length - startIndex; }
        }

        public TcpMessageHandler(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }

        /// <summary>
        /// 收到数据 增加数据长度
        /// </summary>
        public void AddReceiveNum(int addNum)
        {
            startIndex += addNum;
            if (startIndex >= datas.Length)
            {
                Logger.LogDebug("接收数据的数组已装满，可能需要扩展原始大小");
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        public void ReadMessage()
        {
            //包头大小
            int headLen = NetConfig.TCP_MESSAGE_HEAD_LEN;
            while (true)
            {
                //数据不足
                if (startIndex <= headLen)
                {
                    break;
                }
                //包体大小
                int bodyLen = BitConverter.ToInt32(datas, 0);
                //数据包总大小
                int packLen = bodyLen + headLen;
                if (startIndex >= packLen)
                {
                    //包体内容
                    string str = Encoding.UTF8.GetString(datas, headLen, bodyLen);                                      
                    if(str[16]!='0')  //{"ProtocolCode":0      
                        Logger.LogDebug("收到：" + str);
                    try
                    {
                        NetData netData = JsonTool.ToObject<NetData>(str);                      
                        //接收数据 派发事件
                       // NetEventDispatcher.GetInstance().DispatchTcpMsgEvent(netData.ProtocolCode, new TcpReceiveEvParam(netData, tcpClient));
                        tcpClient.OnRevMsg(netData);
                    }
                    catch (Exception e)
                    {
                        Logger.LogDebug("解析数据失败：" + e.ToString());
                    }
                    Array.Copy(datas, packLen, datas, 0, startIndex - packLen);
                    startIndex -= packLen;
                }
                else
                {
                    Logger.LogDebug("数据包不完整 等待下次接收");
                    break;
                }
            }
        }

        /// <summary>
        /// 封装消息
        /// </summary>
        public static byte[] PackMessage(string message)
        {
            //包体
            byte[] bodyData = Encoding.UTF8.GetBytes(message);
            //包头
            byte[] headerBytes = BitConverter.GetBytes(bodyData.Length);//以字节数组的形式返回指定 32 位有符号整数值,返回长度为 4 的字节数组。

            byte[] temBytes = new byte[headerBytes.Length + bodyData.Length];
            Buffer.BlockCopy(headerBytes, 0, temBytes, 0, headerBytes.Length);
            Buffer.BlockCopy(bodyData, 0, temBytes, headerBytes.Length, bodyData.Length);
            return temBytes;
        }
    }
}