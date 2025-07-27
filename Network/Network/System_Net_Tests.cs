using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Net_Security_SslNative	,
//Library_sys_net_native_System_Security_Cryptography_X509Certificates_X509Certificate	ParseCertificate___STATIC__VOID__SZARRAY_U1__BYREF_STRING__BYREF_STRING__BYREF_SystemDateTime__BYREF_SystemDateTime,
//Library_sys_net_native_System_Security_Cryptography_X509Certificates_X509Certificate2	DecodePrivateKeyNative___STATIC__VOID__SZARRAY_U1__STRING,

namespace Network
{
    class System_Net_Tests
    {
        public void Tests()
        {
            Wireless80211ConfigurationTest();
            WirelessAPConfigurationTest();
            AddressConversionsTests();
            IPGlobalProperties_Tests();
            NetworkInterfaceTests();
            CertificateManagerTests();
            SocketTests();
            NetworkSecurityTest();
        }

        private void NetworkSecurityTest()
        {
            //Library_sys_net_native_System_Net_Security_SslNative

            string targetHost= "as";
            X509Certificate clientCertificate = new X509Certificate();
            X509Certificate ca = new X509Certificate();
            X509Certificate serverCertificate = new X509Certificate();
            bool clientCertificateRequired = false;
            SslProtocols enabledSslProtocols = SslProtocols.None;
            Socket socket=null;

            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int SecureServerInit( int sslProtocols, int sslCertVerify, X509Certificate certificate, X509Certificate ca,  bool useDeviceCertificate) -- SecureServerInit___STATIC__I4__I4__I4__SystemSecurityCryptographyX509CertificatesX509Certificate__SystemSecurityCryptographyX509CertificatesX509Certificate__BOOLEAN
            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern void SecureAccept(int contextHandle, object socket) - SecureAccept___STATIC__VOID__I4__OBJECT
            SslStream sslStream = new SslStream(socket);
            sslStream.AuthenticateAsServer( serverCertificate,  clientCertificateRequired, enabledSslProtocols);

            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int SecureClientInit( int sslProtocols,int sslCertVerify,X509Certificate certificate,X509Certificate ca,bool useDeviceCertificate) -- SecureClientInit___STATIC__I4__I4__I4__SystemSecurityCryptographyX509CertificatesX509Certificate__SystemSecurityCryptographyX509CertificatesX509Certificate__BOOLEAN
            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern void SecureConnect(int contextHandle, string targetHost, object socket) -- SecureConnect___STATIC__VOID__I4__STRING__OBJECT
            sslStream.AuthenticateAsClient(targetHost, clientCertificate, ca, enabledSslProtocols);

            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int SecureRead(object socket, byte[] buffer, int offset, int size, int timeout_ms) -- SecureRead___STATIC__I4__OBJECT__SZARRAY_U1__I4__I4__I4
            byte[] readArray = new byte[50];
            int readOffset = 0;
            int readSize = 45;
            sslStream.Read(readArray, readOffset, readSize);

            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int SecureWrite(object socket, byte[] buffer, int offset, int size, int timeout_ms) -- SecureWrite___STATIC__I4__OBJECT__SZARRAY_U1__I4__I4__I4
            byte[] writeArray = new byte[50];
            int writeOffset = 0;
            int writeSize = 45;
            sslStream.Write(writeArray,writeOffset,writeSize);

            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int SecureCloseSocket(object socket) -- SecureCloseSocket___STATIC__I4__OBJECT
            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int ExitSecureContext(int contextHandle) -- ExitSecureContext___STATIC__I4__I4
            // -- Dispose(true)

            //[MethodImplAttribute(MethodImplOptions.InternalCall)]
            //internal static extern int DataAvailable(object socket) -- DataAvailable___STATIC__I4__OBJECT
            bool dataAvailable = sslStream.DataAvailable;

            // Incorrect, uses dataAvailable
            long length = sslStream.Length;
        }

        private void Wireless80211ConfigurationTest()
        {
            // Library_sys_net_native_System_Net_NetworkInformation_Wireless80211Configuration

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static int GetWireless82011ConfigurationCount() -- GetWireless82011ConfigurationCount___STATIC__I4
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static Wireless80211Configuration GetWireless82011Configuration(int configurationIndex)   -GetWireless82011Configuration___STATIC__SystemNetNetworkInformationWireless80211Configuration__I4
            Wireless80211Configuration[] wifiConfigurations = Wireless80211Configuration.GetAllWireless80211Configurations();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static void UpdateConfiguration() -- UpdateConfiguration___STATIC__VOI
            wifiConfigurations[0].SaveConfiguration();
        }
        private void WirelessAPConfigurationTest()
        {

            // Library_sys_net_native_System_Net_NetworkInformation_WirelessAPConfiguration::

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static int GetWirelessAPConfigurationCount() -- GetWirelessAPConfiguration___STATIC__SystemNetNetworkInformationWirelessAPConfiguration__I4
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static WirelessAPConfiguration GetWirelessAPConfiguration(int configurationIndex) -- GetWirelessAPConfigurationCount___STATIC__I4
            WirelessAPConfiguration[] wApConfig = WirelessAPConfiguration.GetAllWirelessAPConfigurations();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static void UpdateConfiguration() -- UpdateConfiguration___STATIC__VOID
            wApConfig[0].SaveConfiguration();
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static WirelessAPStation[] NativeGetConnectedClients(int ClientIndex) -- NativeGetConnectedClients___STATIC__SZARRAY_SystemNetNetworkInformationWirelessAPStation__I4
            WirelessAPStation[] connectedStations = wApConfig[0].GetConnectedStations();
            int stationIndex = 0;
            WirelessAPStation xx = wApConfig[0].GetConnectedStations(stationIndex);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static string NativeDeauthStation(int ClientIndex)  -- NativeDeauthStation___STATIC__STRING__I4
            wApConfig[0].DeAuthStation(stationIndex);
        }
        bool AddressConversionsTests()
        {
            //Library_sys_net_native_System_Net_IPAddress -- IPv4ToString___STATIC__STRING__U4,
            //Library_sys_net_native_System_Net_IPAddress -- IPv6ToString___STATIC__STRING__SZARRAY_U2,

            byte[] anIPAddress = new byte[4] { 45, 23, 78, 92 };

            // IPAddress V4 - by bytes
            IPAddress ipv4Random = new IPAddress(anIPAddress);
            string ipv4RandomIP = ipv4Random.ToString();
            string ipv4Any = IPAddress.Any.ToString();
            string ipv4Loopback = IPAddress.Loopback.ToString();
            string ipv4Broadcast = IPAddress.Broadcast.ToString();

            // IPAddress V4 -by long
            string ipv4FromLong = new IPAddress(0x2414188F).ToString();

            // IPAddress V6
            string ipv6Any = IPAddress.IPv6Any.ToString();
            string ipv6Loopback = IPAddress.Loopback.ToString();

            // scope is only valid fo ipv6 addresses
            long scopeid = 0;
            byte[] ipv6Address = new byte[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, };
            IPAddress ipv6AddressArrayWithScope = new IPAddress(ipv6Address, scopeid);

            return true;
        }
        void IPGlobalProperties_Tests()
        {
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public extern static IPAddress GetIPAddress(); - GetIPAddress___STATIC__SystemNetIPAddress

            // Gets the IP address of the network interface
            IPAddress ip = IPGlobalProperties.GetIPAddress();
        }
        bool NetworkInterfaceTests()
        {
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public extern static bool GetIsNetworkAvailable()   -- GetIsNetworkAvailable___STATIC__BOOLEAN
            bool anyNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //private extern static int GetNetworkInterfaceCount() -- GetNetworkInterfaceCount___STATIC__I4
            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern static NetworkInterface GetNetworkInterface(uint interfaceIndex) -- GetNetworkInterface___STATIC__SystemNetNetworkInformationNetworkInterface__U4
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType) -- UpdateConfiguration___VOID__I4
            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void InitializeNetworkInterfaceSettings() -- InitializeNetworkInterfaceSettings___VOID
            interfaces[0].RenewDhcpLease();
            interfaces[0].ReleaseDhcpLease();

            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType) -- UpdateConfiguration___VOID__I4
            interfaces[0].EnableDhcp();

            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType) -- UpdateConfiguration___VOID__I4
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //internal static extern long IPV4AddressFromString(string ipAddress) -- IPV4AddressFromString___STATIC__I8__STRING
            string[] dnsAddressesIPv4 = new string[] { "192.255.3.1", "192.168.9.0", "192.5.6.7" };
            interfaces[0].EnableStaticIPv4Dns(dnsAddressesIPv4);

            // NOTE: Not properly implemented in code at NetworkInterface.cs:267
            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType) -- UpdateConfiguration___VOID__I4
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //internal static extern long IPV6AddressFromString(string ipAddress) -- IPV6AddressFromString___STATIC__SZARRAY_U2__STRING
            string[] dnsAddressesIPv6 = new string[] { "", "", "" };
            interfaces[0].EnableStaticIPv6Dns(dnsAddressesIPv6);

            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType) -- UpdateConfiguration___VOID__I4
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //internal static extern long IPV4AddressFromString(string ipAddress) -- IPV4AddressFromString___STATIC__I8__STRING
            string ipv4Address = "";
            string ipv4SubnetMask = "";
            string ipv4GatewayAddress = "";
            interfaces[0].EnableStaticIPv4(ipv4Address, ipv4SubnetMask, ipv4GatewayAddress);

            // Not properly implemented in class library System.Net ( NetworkInterface.cs:148)
            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType);
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //internal static extern long IPV4AddressFromString(string ipAddress)-- IPV4AddressFromString___STATIC__I8__STRING
            string ipv6Address = "";
            string ipv6SubnetMask = "";
            string ipv6GatewayAddress = "";
            interfaces[0].EnableStaticIPv6(ipv6Address, ipv6SubnetMask, ipv6GatewayAddress);

            // [MethodImpl(MethodImplOptions.InternalCall)]
            // private extern void UpdateConfiguration(int updateType);
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //internal static extern long IPV4AddressFromString(string ipAddress)-- IPV4AddressFromString___STATIC__I8__STRING
            string ipv4AddressStatic = "";
            string ipv4SubnetMaskStatic = "";
            string ipv4GatewayAddressStatic = "";
            string ipv6AddressStatic = "";
            string ipv6SubnetMaskStatic = "";
            string ipv6GatewayAddressStatic = "";
            interfaces[0].EnableStaticIP(ipv4AddressStatic, ipv4SubnetMaskStatic, ipv4GatewayAddressStatic, ipv6AddressStatic, ipv6SubnetMaskStatic, ipv6GatewayAddressStatic);

            byte[] macAddress = new byte[] { 0, 0x1A, 0x2B, 0x3C, 0x4D, 0x5E };
            interfaces[0].PhysicalAddress = macAddress;

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //internal static extern long IPV4AddressFromString(string ipAddress)-- IPV4AddressFromString___STATIC__I8__STRING

            return true;
        }
        private void CertificateManagerTests()
        {
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern bool AddCaCertificateBundle(byte[] ca) -- AddCaCertificateBundle___STATIC__BOOLEAN__SZARRAY_U1
            X509Certificate[] ca = new X509Certificate[1];
            CertificateManager.AddCaCertificateBundle(ca);
            CertificateManager.AddCaCertificateBundle("");
        }
        private void SocketTests()
        {
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int socket(int family, int type, int protocol) -- socket___STATIC__I4__I4__I4__I4
            AddressFamily addressFamily = AddressFamily.InterNetwork;
            Socket sock = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void bind(object socket, EndPoint address) - bind___STATIC__VOID__OBJECT__SystemNetEndPoint
            IPAddress localAddress = new IPAddress(new byte[] { 0, 0, 0, 0 });
            int port = 40;
            EndPoint localEP = new IPEndPoint(localAddress, port);
            sock.Bind(localEP);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void connect(object socket, EndPoint endPoint, bool fThrowOnWouldBlock) -- connect___STATIC__VOID__OBJECT__SystemNetEndPoint__BOOLEAN
            IPAddress remoteAddress = new IPAddress(new byte[] { 0, 0, 0, 0 });
            EndPoint remoteEP = new IPEndPoint(remoteAddress, port);
            sock.Connect(remoteEP);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int send(object socket, byte[] buf, int offset, int count, int flags, int timeout_ms) -- send___STATIC__I4__OBJECT__SZARRAY_U1__I4__I4__I4__I4
            byte[] bufferReceive = new byte[4096];
            int offsetReceive = 0;
            int sizeReceive = 0;
            SocketFlags socketFlagsReceive = SocketFlags.None;
            sock.Send(bufferReceive, offsetReceive, sizeReceive, socketFlagsReceive);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int recv(object socket, byte[] buf, int offset, int count, int flags, int timeout_ms) -- recv___STATIC__I4__OBJECT__SZARRAY_U1__I4__I4__I4__I4
            byte[] bufferSend = new byte[4096];
            int offsetSend = 0;
            int sizeSend = 0;
            SocketFlags socketFlagsSend = SocketFlags.None;
            sock.Send(bufferSend, offsetSend, sizeSend, socketFlagsSend);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int close(object socket) -- close___STATIC__I4__OBJECT

            // ???? sock.Dis

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void listen(object socket, int backlog) -- listen___STATIC__VOID__OBJECT__I4
            int backlog = 4;
            sock.Listen(backlog);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int accept(object socket) -- accept___STATIC__I4__OBJECT
            sock.Accept();

            //No standard non-blocking api
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void getaddrinfo(string name, out string canonicalName, out byte[][] addresses) -- getaddrinfo___STATIC__VOID__STRING__BYREF_STRING__BYREF_SZARRAY_SZARRAY_U1 
            string hostname = "192.168.1.1";
            IPHostEntry entry = Dns.GetHostEntry(hostname);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void shutdown(object socket, int how, out int err) -- shutdown___STATIC__VOID__OBJECT__I4__BYREF_I4
            // ???????? Not used

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int sendto(object socket, byte[] buf, int offset, int count, int flags, int timeout_ms, EndPoint endPoint) -- sendto___STATIC__I4__OBJECT__SZARRAY_U1__I4__I4__I4__I4__SystemNetEndPoint
            byte[] bufferSendTo = new byte[4096];
            int offsetSendTo = 0;
            int sizeSendTo = 0;
            IPAddress sendToAddress = new IPAddress(new byte[] { 0, 0, 0, 0 });
            EndPoint sendToEP = new IPEndPoint(sendToAddress, port);
            SocketFlags socketFlagsSendTo = SocketFlags.None;
            sock.SendTo(bufferSendTo, offsetSendTo, sizeSendTo, socketFlagsSendTo, sendToEP);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern int recvfrom(object socket, byte[] buf, int offset, int count, int flags, int timeout_ms, ref EndPoint endPoint) -- recvfrom___STATIC__I4__OBJECT__SZARRAY_U1__I4__I4__I4__I4__BYREF_SystemNetEndPoint
            byte[] bufferrecvFrom = new byte[] { 0, 0, 0 };
            int offsetrecvFrom = 0;
            int sizerecvFrom = 9;
            SocketFlags socketFlagsrecvFrom = SocketFlags.None;
            IPAddress recvFromAddress = new IPAddress(new byte[] { 0, 0, 0, 0 });
            EndPoint recvFromEP = new IPEndPoint(recvFromAddress, port);
            int result2 = sock.ReceiveFrom(bufferrecvFrom, offsetrecvFrom, sizerecvFrom, socketFlagsrecvFrom, ref recvFromEP);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void getpeername(object socket, out EndPoint endPoint) -- getpeername___STATIC__VOID__OBJECT__BYREF_SystemNetEndPoint
            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void getsockname(object socket, out EndPoint endPoint) -- getsockname___STATIC__VOID__OBJECT__BYREF_SystemNetEndPoint

            EndPoint localEndPoint = sock.LocalEndPoint;
            EndPoint remoteEndPoint = sock.RemoteEndPoint;

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void getsockopt(object socket, int level, int optname, byte[] optval) -- getsockopt___STATIC__VOID__OBJECT__I4__I4__SZARRAY_U1
            SocketOptionLevel optionLevel = SocketOptionLevel.Socket;
            SocketOptionName optionName = SocketOptionName.AcceptConnection;
            byte[] byteArrayValue = new byte[] { 0, 0, 0, 0 };
            sock.GetSocketOption(optionLevel, optionName, byteArrayValue);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void setsockopt(object socket, int level, int optname, byte[] optval) -- setsockopt___STATIC__VOID__OBJECT__I4__I4__SZARRAY_U1
            SocketOptionLevel setOptionLevel = SocketOptionLevel.Socket;
            SocketOptionName setOptionName = SocketOptionName.ReceiveBuffer;
            int SetOptionValue = 4;
            sock.SetSocketOption(setOptionLevel, setOptionName, SetOptionValue);

            byte[] setOptionValueArray = new byte[] { 0, 0, 0, 0 };
            sock.SetSocketOption(setOptionLevel, setOptionName, setOptionValueArray);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern bool poll(object socket, int mode, int microSeconds) -- poll___STATIC__BOOLEAN__OBJECT__I4__I4
            int microSeconds = 500;
            SelectMode mode = SelectMode.SelectRead;
            sock.Poll(microSeconds, mode);

            //[MethodImpl(MethodImplOptions.InternalCall)]
            //public static extern void ioctl(object socket, uint cmd, ref uint arg) - ioctl___STATIC__VOID__OBJECT__U4__BYREF_U4
            int availableResult = sock.Available;

        }
    }
}