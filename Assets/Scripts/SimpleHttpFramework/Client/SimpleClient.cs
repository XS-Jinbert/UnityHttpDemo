using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SimpleHttpFramework.Utils;
using Bilibili.Url;
using Bilibili.Message;
using UnityEngine;

namespace SimpleHttpFramework.Client
{
    public class SimpleClient
    {
        public bool Connecting;

        private string Host = BUrl.LIVE_ROOM_HOST;
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// 连接与服务器建立连接
        /// </summary>
        /// <returns></returns>
        public async Task<bool> PrepareRoomState(int roomId)
        {
            // bilibili官方直播弹幕Api
            var url = $"{Host}{BUrl.LIVE_ROOM_STATE_URL}{roomId}";

            // 正确发送Get
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var header = request.Headers;

            var resp = await client.SendAsync(request);
            var statusCode = resp.StatusCode;

            string requestBack = await resp.Content.ReadAsStringAsync();
            Debug.Log(JsonUtils.JsonToObj<LiveRoomMessage>(requestBack).message);
            return true;
        }

        /// <summary>
        /// 向服务器发送心跳包
        /// </summary>
        private async Task<bool> Heartbeat()
        {
            while (!Connecting)
            {
                await Task.Delay(5000);
            }
            return false;
        }
    }
}
