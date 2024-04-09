namespace Server.Models.Net
{
    public class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 机号
        /// </summary>
        public int MachineId;

        /// <summary>
        /// 席位编号
        /// </summary>
        public int SeatId;

        /// <summary>
        /// 机型
        /// </summary>
        public int CarId;

        /// <summary>
        /// 客户端数据
        /// </summary>
        public InitModel initModel;
    }

}
