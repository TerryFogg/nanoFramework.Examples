using System.Device.Wifi;

namespace Network
{
    public class WifiTest
    {
        public void Tests()
        {
            WifiTests();
        }
        private void WifiTests()
        {
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern void NativeInit();
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private static extern byte[] NativeFindWirelessAdapters();
            WifiAdapter[] x = WifiAdapter.FindAllAdapters();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern void DisposeNative();
            x[0].Disconnect();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern WifiConnectionStatus NativeConnect(string Ssid, string passwordCredential, WifiReconnectionKind reconnectionKind);
            WifiAvailableNetwork availableWifiNetwork = new();
            WifiReconnectionKind reconnectionKind = WifiReconnectionKind.Manual;
            string passwordCredential = "";
            WifiConnectionResult wifiResult = x[0].Connect(availableWifiNetwork,  reconnectionKind, passwordCredential);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern void NativeDisconnect();
            x[0].Disconnect();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern void NativeScanAsync();
            x[0].ScanAsync();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern byte[] GetNativeScanReport();
            WifiNetworkReport wnr = x[0].NetworkReport;
        }
    }
}
