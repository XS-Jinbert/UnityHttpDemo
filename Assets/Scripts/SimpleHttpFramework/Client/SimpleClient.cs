using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace SimpleHttpFramework.Client
{
    public class SimpleClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<bool> BeginNetwork()
        {
            // bilibili官方直播弹幕Api
            var host = "https://api.live.bilibili.com/";
            var path = "xlive/web-room/v1/dM/gethistory?roomid=";

            // 正确发送Get
            var request = new HttpRequestMessage(HttpMethod.Get, $"{host}{path}{33989}");
            Debug.Log(request.Headers);
            var resp = await client.SendAsync(request);


            Debug.Log(resp.StatusCode);
            Debug.Log(await resp.Content.ReadAsStringAsync());
            return true;
        }
    }
}
