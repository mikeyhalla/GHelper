using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Logger.Logging;

namespace GHelper
{
    public class SendGameUDP
    {
        public static string IpAddress = "::1";
        static IPEndPoint ServerEndPoint;
        static readonly byte[] data = new byte[256];

        public static void ServerTalk()
        {
            if (PingHost(IpAddress))
            {

                Info("using IPv6", "GHelperForm");
                IPv6();
            }
            else
            {
                Info("Using IPv4", "GHelperForm");
                IPv4();
            }
        }
        static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;

            Ping pinger = new Ping();

            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                MessageBox.Show(ex.Message, "GHelper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (pinger != null)
                    pinger.Dispose();
            }
            return pingable;
        }

        public static void IPv6()
        {
            using (Socket WinSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp))
            {
                WinSocket.ReceiveTimeout = 0;
                WinSocket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, 0);
                IpAddress = "::1";
                IPAddress AddressProtocol = IPAddress.IPv6Any;
                ServerEndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), 80);
                IPEndPoint sender = new IPEndPoint(AddressProtocol, 0);
                WinSocket.Bind(ServerEndPoint);
                EndPoint Remote = sender;

                while (true)
                {
                    int recv = WinSocket.ReceiveFrom(data, ref Remote);
                    GHelperForm.GameRunning = Encoding.ASCII.GetString(data, 0, recv);

                    Thread.Sleep(500);
                }
            }
        }
        public static void IPv4()
        {
            using (Socket WinSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                WinSocket.ReceiveTimeout = 0;
                WinSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
                IpAddress = "127.0.0.1";
                IPAddress AddressProtocol = IPAddress.Any;
                ServerEndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), 80);
                IPEndPoint sender = new IPEndPoint(AddressProtocol, 0);
                WinSocket.Bind(ServerEndPoint);
                EndPoint Remote = sender;

                while (true)
                {
                    int recv = WinSocket.ReceiveFrom(data, ref Remote);
                    GHelperForm.GameRunning = Encoding.ASCII.GetString(data, 0, recv);

                    Thread.Sleep(500);
                }
            }
        }
    }
}
