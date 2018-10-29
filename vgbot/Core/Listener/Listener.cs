using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace Vgbot.Core.Listener
{
    public class Listener
    {
        private readonly UdpClient _udpClient;
        private readonly BlockingCollection<byte[]> _buffer;
        public bool IsListening { get; private set; }

        public Listener(BlockingCollection<byte[]> buffer)
        {
            _udpClient = new UdpClient(3000);
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
            _buffer.Add(_udpClient.EndReceive(res, ref remoteIpEndPoint));
            if(IsListening)
            {
                _udpClient.BeginReceive(DataReceived, null);
            }
        }        
    }
}
