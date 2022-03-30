using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace SimpleHttpFramework.Utils
{
    public class JsonUtils
    {
        public static string ToString(object obj)
        {
            return JsonMapper.ToJson(obj);
        }
    }
}
