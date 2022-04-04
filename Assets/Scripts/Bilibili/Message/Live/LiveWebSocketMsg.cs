namespace Bilibili.Message
{
    /// <summary>
    /// 哔哩哔哩弹幕数据
    /// </summary>
    public class LiveWebSocketMsg
    {
        public int uid { get; set; }
        public int roomid { get; set; }
        public int protover { get; set; }
        public string platform { get; set; }
        public string clientver { get; set; }
        public int type { get; set; }
        public string key { get; set; }
    }
}