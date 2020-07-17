using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using BingLibrary.hjb;


namespace SxjLibrary
{
    public class Udp
    {
        private string _remoteIp;

        public string RemoteIP
        {
            get { return _remoteIp; }
            set { _remoteIp = value; }
        }
        private int _remotePort;

        public int RemotePort
        {
            get { return _remotePort; }
            set { _remotePort = value; }
        }
        private int _localPort;

        public int LocalPort
        {
            get { return _localPort; }
            set { _localPort = value; }
        }


        private int _timeout;

        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        private UdpClient mUdp;
        private IPEndPoint remoteIpEndPoint;
        private IPEndPoint localIpEndPoint;

        public Udp(string remoteIp,int remotePort,int localPort,int timeout)
        {
            RemoteIP = remoteIp;
            RemotePort = remotePort;
            LocalPort = localPort;
            Timeout = timeout;
            mUdp = new UdpClient(LocalPort);
            remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(RemoteIP), RemotePort);
            localIpEndPoint = new IPEndPoint(IPAddress.Any, LocalPort);

            mUdp.Client.ReceiveTimeout = Timeout;
            mUdp.Client.SendTimeout = Timeout;
        }
        /// <summary>
        /// 发送字符串，再等接收
        /// </summary>
        /// <param name="Str">发送的字符串</param>
        /// <returns>接收到的字符串</returns>
        public string UdpSendthenReceive(string Str)
        {
            try
            {
                while (mUdp.Available > 0)
                {
                    mUdp.Receive(ref localIpEndPoint);
                }
                byte[] b = Encoding.UTF8.GetBytes(Str);
                mUdp.Send(b, b.Length, remoteIpEndPoint);
                byte[] receiveBytes = mUdp.Receive(ref localIpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                return returnData;
            }
            catch(Exception ex)
            {
                Log.Default.Error("Udp 发送或接收错误" + localIpEndPoint.Port.ToString(), ex);
                return "Udp 发送或接收错误";
            }
        }
    }
}
