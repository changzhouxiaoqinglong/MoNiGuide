namespace Server.Constant
{
    public class NetConfig : ConfigBase<NetConfig>
    {
        /// <summary>
        /// IP地址
        /// </summary>

        public static string IP;

        /// <summary>
        /// 接口
        /// </summary>
        public static int PORT;

        /// <summary>
        /// TCP连接 消息包头的大小 包头保存包体大小 int型 占4字节
        /// </summary>
        public static int TCP_MESSAGE_HEAD_LEN;

        /// <summary>
        /// tcp最大连接数
        /// </summary>
        public static int TCP_CONNECT_NUM;

        /// <summary>
        /// 断开连接 心跳超时时间 s
        /// </summary>
        public static int HEART_BEAT_TIME_OUT;

        public static void InitConfig()
        {
            ParseConfigByReflection("Configs/NetConfig.cfg");
        }
    }
}
