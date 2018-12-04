using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using vgbot.Model;
using Vgbot.Core.Messages;

namespace vgbot.Core.Manager
{
    class MatchManager
    {
        private readonly Dictionary<IPEndPoint, Match> _ongoingMatches = new Dictionary<IPEndPoint, Match>();

        private Match GetRelatedMatch(AbstractMessage message)
        {
            foreach (var matchKey in _ongoingMatches.Keys)
            {
                if (matchKey.Equals(message.IpEndPoint))
                {
                    return _ongoingMatches[matchKey];
                }
            }
            _ongoingMatches.Add(message.IpEndPoint, new Match());
            return _ongoingMatches[message.IpEndPoint];
        }

        public void ProcessMessage(AbstractMessage message)
        {
            var match = GetRelatedMatch(message);
            message.Process(match);
        }
    }
}
