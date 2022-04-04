using LitJson;
using System.Collections.Generic;

namespace NetClient.ClientProxy.Interface
{
    public interface IClientProxy
    {
        /// <summary>
        /// 解析数据
        /// </summary>
        void ParseData(List<JsonData> JsonData);
    }
}