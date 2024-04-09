using System;



    /// <summary>
    /// 接收发送网络数据处理 属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class NetMsgHandleAttribute : Attribute
    {
        /// <summary>
        /// 协议号
        /// </summary>
        public int ProtocolCode { get; private set; }

        /// <summary>
        /// 是否是接收消息
        /// </summary>
        public bool IsReceive { get; private set; }

        /// <summary>
        /// 属性
        /// </summary>
        /// <param name="protocolCode">协议号</param>
        /// <param name="isReceive">是否是接收消息 false就是发送  true就是接收</param>
        public NetMsgHandleAttribute(int protocolCode, bool isReceive)
        {
            ProtocolCode = protocolCode;
            IsReceive = isReceive;
        }
    }

