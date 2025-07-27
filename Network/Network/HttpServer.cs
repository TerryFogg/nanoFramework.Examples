using nanoFramework.Networking;
using System;
using System.Collections.Generic;
using System.Device.Wifi;
using System.Text;
using System.Threading;

namespace Network
{
    internal class HttpServer
    {

        HttpServer()
        {
            string MySsid = "ssid";
            string MyPassword = "password";
            CancellationTokenSource cs = new(60000);
            bool success = WifiNetworkHelper.ConnectDhcp(MySsid, MyPassword, requiresDateTime: true, token: cs.Token);


        }
    }
}
