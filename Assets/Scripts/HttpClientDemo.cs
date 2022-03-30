using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using SimpleHttpFramework.Client;

public class HttpClientDemo : MonoBehaviour
{
    private SimpleClient Client = new SimpleClient();

    async void Start()
    {
        await Client.BeginNetwork();
    }
}
