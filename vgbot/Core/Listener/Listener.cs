using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using vgbot.Core.Listener;

namespace Vgbot.Core.Listener
{
    public class Listener
    {
        private readonly UdpClient _udpClient;
        private readonly BlockingCollection<DataPacket> _buffer;
        public bool IsListening { get; private set; }

        public Listener(BlockingCollection<DataPacket> buffer, int port)
        {
            _udpClient = new UdpClient(port);
            _buffer = buffer;
        }

        public void BeginListening()
        {
            try
            {
                IsListening = true;
                _udpClient.BeginReceive(DataReceived, null);
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
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            var dataPacket = new DataPacket(_udpClient.EndReceive(res, ref remoteIpEndPoint), remoteIpEndPoint);
            _buffer.Add(dataPacket);
            if(IsListening)
            {
                _udpClient.BeginReceive(DataReceived, null);
            }
        }        
    }
}
