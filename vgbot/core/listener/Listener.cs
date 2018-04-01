using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace vgbot.core.listener
{
    public class Listener
    {
        private readonly UdpClient udpClient;
        private readonly BlockingCollection<byte[]> buffer;
        public bool IsListening { get; private set; }

        public Listener(BlockingCollection<byte[]> buffer)
        {
            udpClient = new UdpClient(3000);
            this.buffer = buffer;
        }

        public void BeginListening()
        {
            try
            {
                IsListening = true;
                udpClient.BeginReceive(new AsyncCallback(DataReceived), null);
            }
            catch
            {
                IsListening = false;
            }
        }
        
        public void EndListening()
        {
            IsListening = false;
        }

        private void DataReceived(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            buffer.Add(udpClient.EndReceive(res, ref RemoteIpEndPoint));
            if(IsListening)
            {
                udpClient.BeginReceive(new AsyncCallback(DataReceived), null);
            }
        }        
    }
}
