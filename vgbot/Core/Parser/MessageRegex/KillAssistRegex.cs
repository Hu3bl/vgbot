using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class KillAssistRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "assisted killing \"(?<killedUserName>.+)[<](?<killedUserId>\\d+)[>][<](?<killedSteamId>.*)[>][<](?<killedUserTeam>CT|TERRORIST|Unassigned|Spectator)[>]\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                KillAssistMessage message = new KillAssistMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups[1].Value;
                message.UserID = match.Groups[2].Value;
                message.UserSteamID = match.Groups[3].Value;
                message.UserTeam = match.Groups[4].Value;
                message.KilledUserName = match.Groups[5].Value;
                message.KilledUserID = match.Groups[6].Value;
                message.KilledUserSteamID = match.Groups[7].Value;
                message.KilledUserTeam = match.Groups[8].Value;
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}