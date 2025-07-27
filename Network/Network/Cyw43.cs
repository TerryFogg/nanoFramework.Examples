using System;
using System.Device.Wifi;

namespace Network
{
    // Current support for one wifi adapter
    public class Cyw43
    {
        public Cyw43()
        {
            WifiAdapter[] wifi = WifiAdapter.FindAllAdapters();

            wifi[0].ScanAsync();
            wifi[0].Connect("ssid", WifiReconnectionKind.Manual, "passwordCredential");

            wifi[0].AvailableNetworksChanged+=Cyw43_AvailableNetworksChanged;
            int networkInterfaceNumber = wifi[0].NetworkInterface;

            WifiNetworkReport listOfNetworks = wifi[0].NetworkReport;
        }
        private void Cyw43_AvailableNetworksChanged(WifiAdapter sender, object e)
        {
            throw new NotImplementedException();
        }
    }
}
