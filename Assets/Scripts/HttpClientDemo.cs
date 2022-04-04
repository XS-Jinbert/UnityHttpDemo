using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using NetClient.Client;

public class HttpClientDemo : MonoBehaviour
{
    public InputField LiveRoomIdInput;

    private int RoomId;
    private SimpleClient Client = new SimpleClient();

    async void Connect()
    {
        bool isConnent = await Client.PrepareRoomInfo(RoomId);
        if (isConnent)
        {
            Client.StartConnect();
        }
    }

    public void GetConnect()
    {
        if(LiveRoomIdInput != null)
        {
            if (string.IsNullOrEmpty(LiveRoomIdInput.text))
            {
                Debug.LogError("请输入正确的RoomId！");
            }
            else
            {
                RoomId = int.Parse(LiveRoomIdInput.text);
                Connect();
            }
        }
    }

    public void CloseConnect()
    {
        if (Client.Connecting)
        {
            Client.CloseConnect();
            Debug.LogWarning("链接已关闭");
        }
    }

    private void OnDestroy()
    {
        CloseConnect();
    }
}
