using System.Collections;
using System.Collections.Generic;

namespace SimpleHttpFramework.DataEntity.Bilibili
{
    /// <summary>
    /// 哔哩哔哩弹幕数据
    /// </summary>
    public class BiliBulletChatData
    {
        Dictionary<string, object> jsonData = new Dictionary<string, object>();

        public bool isEmpty { get { return jsonData.Count <= 0; } }

        public void SetKeyValue(string key, object value)
        {
            jsonData[key] = value;
        }

        public T GetValue<T>(string key)
        {
            return (T)jsonData[key];
        }
    }
}
