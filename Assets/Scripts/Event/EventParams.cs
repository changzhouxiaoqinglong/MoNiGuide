using Server.Models;
using Server.Models.Net;
using Server.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpServer.Servers;

namespace Server.Event
{
    public interface IEventParam { }

    public class StringEvParam : IEventParam
    {
        string value;
        public StringEvParam(string value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// 接收消息 事件参数
    /// </summary>
    public class TcpReceiveEvParam : IEventParam
    {
        public NetData netData;

        public TcpClient client;

        public TcpReceiveEvParam(NetData netData, TcpClient client)
        {
            this.netData = netData;
            this.client = client;
        }
    }
}
