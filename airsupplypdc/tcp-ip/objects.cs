using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace AirSupplyPDC.TCP_IP
{
    public class TransactionInfor
    {
        public Guid Guid { get; set; }
        public DateTime EventOccur { get; set; }
        public string IPSend { get; set; }
        public string SendData { get; set; }
        public string RespondData { get; set; }
        public bool isSuccess { get; set; }
    }
    public class TaskOrder
    {
        public Task task { get; set; }
        public int id { get; set; }
    }
    public class CellInfor
    {
        public int idCell { get; set; }
        public int idModel { get; set; }
        public int idMer { get; set; }
    }
    public class ServerInfor
    {
        public Server Server { get; set; }
        public int Port { get; set; }
        public bool isStart { get; set; } = false;
        public bool Start()
        {
            try
            {
                Server = new Server() { Port_ = Port };
                return Server.Start();
            }
            catch { }
            return false;
        }
        public bool Stop()
        {
            try
            {
                if (Server != null)
                {
                    Server.Stop();
                }
            }
            catch { return false; }
            return true;
        }
        public int[] listPort
        {
            get
            {
                List<int> Ports = new List<int>();
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                IEnumerator myEnum = tcpConnInfoArray.GetEnumerator();
                while (myEnum.MoveNext())
                {
                    TcpConnectionInformation TCPInfo = (TcpConnectionInformation)myEnum.Current;
                    Ports.Add(TCPInfo.LocalEndPoint.Port);
                }
                return Ports.ToArray();
            }
        }
    }
}
