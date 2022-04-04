using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;

namespace NetClient.Utils
{
    public class CSJsonUtils
    {
        public static string ObjToJson<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream writer = new MemoryStream();
            serializer.WriteObject(writer, obj);
            writer.Position = 0;
            StreamReader reader = new StreamReader(writer, Encoding.UTF8);
            string json = reader.ReadToEnd();
            reader.Close();
            writer.Close();
            return json;
        }

        public static T JsonToObj<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream reader = new MemoryStream(Encoding.Unicode.GetBytes(json));

            T model = (T)serializer.ReadObject(reader);
            reader.Close();
            return model;
        }
    }

    public class JsonUtils
    {
        public static string ObjToJson<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static T JsonToObj<T>(string json)
        {
            T model = (T)JsonConvert.DeserializeObject<T>(json);
            return model;
        }
    }
}
