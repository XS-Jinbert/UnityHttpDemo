namespace Bilibili.Url
{
    public class BUrl
    {
        /// <summary>
        /// 直播房间基础路径
        /// </summary>
        public const string LIVE_ROOM_HOST = "https://api.live.bilibili.com/";
        /// <summary>
        /// 访问直播房间状态Url，Id = 房间号
        /// </summary>
        public const string LIVE_ROOM_STATE_URL = "room/v1/Room/room_init?id=";
    }
}