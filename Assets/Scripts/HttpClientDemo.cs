using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[DataContract]
internal class SimpleReq
{
    [DataMember]
    public string foo;
}

public class HttpClientDemo : MonoBehaviour
{
    async void Start()
    {
        await BeginNetwork();
    }

    public static string ToJsonString<T>(T data)
    {
        var stream1 = new MemoryStream();
        var ser = new DataContractJsonSerializer(typeof(T));
        ser.WriteObject(stream1, data);

        stream1.Position = 0;
        StreamReader sr = new StreamReader(stream1);
        var jsonBody = sr.ReadToEnd();

        return jsonBody;
    }

    private static readonly HttpClient client = new HttpClient();

    /*
    ProtocolViolationException: Cannot send data when method is: GET
     */
    async Task<bool> BeginNetwork()
    {
        var host = "http://127.0.0.1:3100";
        var path = "/v1/user/mydata";
        var body = ToJsonString(new SimpleReq()
        {
            foo = "bar",
        });

        var request = new HttpRequestMessage(HttpMethod.Get, $"{host}{path}")
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json"),
        };
        Debug.Log(request.Headers);
        var resp = await client.SendAsync(request);


        Debug.Log(resp.StatusCode);
        Debug.Log(await resp.Content.ReadAsStringAsync());
        return true;
    }
}
