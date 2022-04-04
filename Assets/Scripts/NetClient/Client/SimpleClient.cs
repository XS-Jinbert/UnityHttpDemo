using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NetClient.Utils;
using Bilibili.Url;
using Bilibili.Message;
using UnityEngine;
using NetClient.WebSocket;
using NetClient.ClientProxy.Interface;
using LitJson;
using System.Text;

namespace NetClient.Client
{
    public class SimpleClient : IClientProxy
    {
        public bool Connecting { 
            get {
                if (WebConnent == null) return false;
                else return WebConnent.IsLink;
            } 
        }
        public int RoomId;

        private string Host = BilibiliUrl.LIVE_ROOM_HOST;
        private static readonly HttpClient client = new HttpClient();

        WebSocketConnent WebConnent;

        /// <summary>
        /// 连接与服务器建立连接
        /// </summary>
        /// <returns></returns>
        public async Task<bool> PrepareRoomInfo(int roomId)
        {
            RoomId = roomId;
            // bilibili官方直播弹幕Api
            var url = $"{Host}{BilibiliUrl.LIVE_ROOM_STATE_URL}{roomId}";

            // 正确发送Get
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var header = request.Headers;

            var resp = await client.SendAsync(request);
            var statusCode = resp.StatusCode;

            string requestBack = await resp.Content.ReadAsStringAsync();
            Debug.Log(JsonUtils.JsonToObj<LiveRoomInfoMsg>(requestBack).message);
            return true;
        }

        /// <summary>
        /// 开始连接
        /// </summary>
        public void StartConnect()
        {
            string webUrl = "wss://broadcastlv.chat.bilibili.com:2245/sub";

            LiveWebSocketMsg webRequestMessage = new LiveWebSocketMsg();
            webRequestMessage.uid = 0;
            webRequestMessage.roomid = RoomId;
            webRequestMessage.protover = 3;
            webRequestMessage.platform = "web";
            webRequestMessage.clientver = "1.6.3";
            webRequestMessage.type = 2;
            webRequestMessage.key = "token";
            string json = JsonUtils.ObjToJson(webRequestMessage);
            MsgBody sBody = new MsgBody(json);
            sBody.PacketLength = Encoding.UTF8.GetBytes(json).Length + 16;
            sBody.HeaderLength = 16;
            sBody.ProtocolVersion = 1;
            sBody.Operation = 7;
            sBody.SequenceId = 1;
            // Debug.Log(sBody.ToByteArray()[5]);

            MsgBody hBody = new MsgBody("");
            hBody.PacketLength = Encoding.UTF8.GetBytes("").Length + 16;
            hBody.HeaderLength = 16;
            hBody.ProtocolVersion = 1;
            hBody.Operation = 2;
            hBody.SequenceId = 1;

            WebConnent = new WebSocketConnent(webUrl, this, sBody, hBody);

            WebConnent.StartConnect();
        }

        public void CloseConnect()
        {
            WebConnent.CloseConnect();
        }

        public void ParseData(List<JsonData> JsonData)
        {
            foreach (var msgItem in JsonData)
            {
                //Debug.Log(msgItem.ToJson());
                if ((string)msgItem["cmd"] == "DANMU_MSG")
                {
                    string name = msgItem["info"][2][1].ToString();
                    string context = msgItem["info"][1].ToString();

                    string show = $"弹幕：{name}：{context}";
                    Debug.Log(show);
                }
                if ((string)msgItem["cmd"] == "SEND_GIFT")
                {
                    string name = msgItem["data"]["uname"].ToString();
                    string gifNname = msgItem["data"]["giftName"].ToString();
                    string action = msgItem["data"]["action"].ToString();

                    string show = $"送礼：用户 {name} {action}了{gifNname}";
                    Debug.Log(show);
                }
            }
        }
    }
}
