using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace AirSupplyPDC.TCP_IP
{
    public class Server
    {

        public delegate void CloseHandler(Client client, bool isconnect);
        public CloseHandler iConnect = delegate { };
        public delegate void StreamData(Guid GuidStr, string iDataConnect, string content, string respond, bool isSuccess);
        public StreamData DataStream = delegate { };
        public delegate void UpdateCabinet(int _idCabinet);
        public delegate void UpdateListCaninet(int[] _idCabinet);
        public UpdateCabinet updateCab = delegate { };
        public UpdateListCaninet updatelsCab = delegate { };


        List<Client> clients = new List<Client>();
        public int Port_ { get; set; } = 1100;
        private TcpListener listener_ { get; set; } = null;
        public bool Start()
        {
            try
            {
                listener_ = new TcpListener(IPAddress.Any, Port_);
                listener_.Start();
                Thread listenthrd = new Thread(RunningServer);
                listenthrd.Start();
                return true;
            }
            catch { }
            return false;
        }
        public Server()
        {

        }
        public void Stop()
        {
            if (listener_ != null)
            {
                listener_.Stop();
                listener_ = null;
            }
        }
        private void RunningServer()
        {
            try
            {
                while (true)
                {
                    TcpClient tcpClient_ = listener_.AcceptTcpClient();
                    try
                    {
                        //ThreadPool.QueueUserWorkItem((x) => ThreadProc(tcpClient_));
                        //Task taskclient = new Task(() => ThreadProc(tcpClient_));
                        //taskclient.Start();
                        Task.Factory.StartNew(() => ThreadProc(tcpClient_));
                        //ThreadProc(tcpClient_);
                    }
                    catch { }
                }
            }
            catch { };
        }

        private void ThreadProc(object obj)
        {
            if (obj is TcpClient client)
            {
                Client client_ = new Client() { };
                client_.DataStream = (a, b, c, d, f) => DataStream(a, b, c, d, f);
                client_.iConnect = (a, b) => iConnect(a, b);
                client_.updateCab = (b) => updateCab(b); ;
                client_.updatelsCab = (b) => updatelsCab(b); ;
                client_.Run(client);
                client_ = null;
                client.Dispose();
                GC.Collect();
            }
        }
        public bool PingHost(string host, int timeout = 500)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(host, timeout);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
