using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using SimpleHttpFramework.Client;

public class HttpClientDemo : MonoBehaviour
{
    [Header("B站直播房间号")]
    public int RoomId;
    private SimpleClient Client = new SimpleClient();

    async void Start()
    {
        bool isConnent = await Client.PrepareRoomState(RoomId);
    }
}
