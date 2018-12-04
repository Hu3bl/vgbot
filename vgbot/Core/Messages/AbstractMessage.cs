using System.Net;
using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public abstract class AbstractMessage
    {
        public IPEndPoint IpEndPoint { get; set; }
        public abstract void Process(Match match);
    }
}