using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class KillAssistRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "assisted killing \"(?<killedUserName>.+)[<](?<killedUserId>\\d+)[>][<](?<killedSteamId>.*)[>][<](?<killedUserTeam>CT|TERRORIST|Unassigned|Spectator)[>]\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                KillAssistMessage message = new KillAssistMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.KilledUserName = match.Groups["killedUserName"].Value;
                message.KilledUserID = match.Groups["killedUserId"].Value;
                message.KilledUserSteamID = match.Groups["killedSteamId"].Value;
                message.KilledUserTeam = match.Groups["killedUserTeam"].Value;
                                                                     
                return message;
            }
            return null;
        }
    }
}