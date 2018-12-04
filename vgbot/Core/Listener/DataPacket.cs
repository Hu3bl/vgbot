using System.Net;

namespace vgbot.Core.Listener
{
    public class DataPacket
    {
        public byte[] Data { get; }
        public IPEndPoint From { get; }

        public DataPacket(byte[] data, IPEndPoint from)
        {
            Data = data;
            From = from;
        }
    }
}
