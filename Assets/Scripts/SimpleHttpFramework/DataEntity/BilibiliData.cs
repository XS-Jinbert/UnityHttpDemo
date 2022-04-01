using System.Collections;
using System.Collections.Generic;

namespace Bilibili.Message
{
    public class LiveRoomMessage
    {
        public int code { get; set; }
        public string msg { get; set; }
        public string message { get; set; }
        public LiveRoomMessageData data { get; set; }
    }

    public class LiveRoomMessageData
    {
        public int room_id { get; set; }
        public int short_id { get; set; }
        public int uid { get; set; }
        public int need_p2p { get; set; }
        public bool is_hidden { get; set; }
        public bool is_locked { get; set; }
        public bool is_portrait { get; set; }
        public int live_status { get; set; }
        public int hidden_till { get; set; }
        public int lock_till { get; set; }
        public bool encrypted { get; set; }
        public bool pwd_verified { get; set; }
        public long live_time { get; set; }
        public int room_shield { get; set; }
        public int is_sp { get; set; }
        public int special_type { get; set; }
    }

    /// <summary>
    /// 哔哩哔哩弹幕数据
    /// </summary>
    public class BulletChatMessage
    {
        
    }
}
