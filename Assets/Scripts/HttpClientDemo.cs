using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LitJson;

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

    // 生成Json
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

    async Task<bool> BeginNetwork()
    {
        // bilibili官方直播弹幕Api
        var host = "https://api.live.bilibili.com/";
        var path = "xlive/web-room/v1/dM/gethistory?roomid=";
        var body = ToJsonString(new SimpleReq()
        {
            foo = "bar",
        });

        // 正确发送Get
        var request = new HttpRequestMessage(HttpMethod.Get, $"{host}{path}{33989}");
        // ProtocolViolationException: Cannot send data when method is: GET
        // var request = new HttpRequestMessage(HttpMethod.Get, $"{host}{path}")
        // {
        //     Content = new StringContent(body, Encoding.UTF8, "application/json"),
        // };
        Debug.Log(request.Headers);
        var resp = await client.SendAsync(request);


        Debug.Log(resp.StatusCode);
        Debug.Log(await resp.Content.ReadAsStringAsync());
        return true;
    }
}

public class Bilibili
{
    string text;    // 弹幕消息

    long uid;   // 发送该条弹幕的用户id

    string nickname;    //用户昵称

    //uname_color:用户昵称颜色

    // timeline; // 发送弹幕时间

    bool isadmin;   //是否是房间管理员

    bool vip;   // 未知，俺穷，不知道vip是啥

    bool svip;  // 未知，我连VIP都不是，SVIP更不知道了

    //medal：该用户佩戴的徽章信息[徽章等级, 徽章名称，还有其他的]

    //title：未知，基本都是为空

    //user_level：用户等级数据（UL）

    //rank：不清楚是什么，所有人都是10000

    //以下数据应该是属于某个活动的专属数据块

    //teamid：未知

    //rnd：未知

    //user_title：未知

    //guard_level：未知

    //bubble：未知

    //bubble_color：未知

    //lpl：LPL活动吧数据吧
}
