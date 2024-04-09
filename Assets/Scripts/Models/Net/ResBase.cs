
using Server.Constant;

namespace Server.Models.Net
{
    public class ResBase
    {
        public int Code = NetConstantt.RES_SUCCESS;

        /// <summary>
        /// 提示消息
        /// </summary>
        public string Tip;

        public bool IsSuccess()
        {
            return Code == NetConstantt.RES_SUCCESS;
        }
    }
}
