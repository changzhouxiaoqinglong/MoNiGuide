using static Server.Event.EventDispatcher;

namespace Server.Event
{
    public class NetEventDispatcher : SingleTonBase<NetEventDispatcher>
    {
        /// <summary>
        /// 添加网络数据接收监听
        /// </summary>
        /// <param name="protocolCode">监听的协议号</param>
        /// /// <param name="handler">监听事件</param>
        public void AddTcpMsgEventListener(int protocolCode, EventHandler handler)
        {
            EventDispatcher.GetInstance().AddEventListener(GetTcpMsgEventKey(protocolCode), handler);
        }

        /// <summary>
        /// 移除网络数据接收监听
        /// </summary>
        /// <param name="type">对应服务器</param>
        /// <param name="protocolCode">监听的协议号</param>
        /// <param name="handler">监听事件</param>
        public void RemoveTcpMsgEventListener(int protocolCode, EventHandler handler)
        {
            EventDispatcher.GetInstance().RemoveEventListener(GetTcpMsgEventKey(protocolCode), handler);
        }

        /// <summary>
        /// 接收到网络数据 事件派发
        /// </summary>
        public void DispatchTcpMsgEvent(int protocolCode, IEventParam param)
        {
            EventDispatcher.GetInstance().DispatchEvent(GetTcpMsgEventKey(protocolCode), param);
        }

        /// <summary>
        /// 获取网络消息事件 对应的key
        /// </summary>
        /// <param name="protocolCode">监听的协议号</param>
        private string GetTcpMsgEventKey(int protocolCode)
        {
            return EventNameList.ON_RECEIVE_TCP_MSG + "_" + protocolCode;
        }
    }
}
