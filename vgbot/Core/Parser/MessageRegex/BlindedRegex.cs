using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class BlindedRegex : IRegex
    {
        private static readonly string pattern = "\"(?<victimUserName>.+)[<](?<victimUserId>\\d+)[>][<](?<victimUserSteamId>.*)[>][<](?<victimUserTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
         + "blinded for (?<duration>.+) by \"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" from flashbang entindex (?<entindex>\\d+)";
       
        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                BlindedMessage message = new BlindedMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.VictimUserName = match.Groups["victimUserName"].Value;
                message.VictimUserID = match.Groups["victimUserId"].Value;
                message.VictimUserSteamID = match.Groups["victimUserSteamId"].Value;
                message.VictimUserTeam = match.Groups["victimUserTeam"].Value;
                Double.TryParse(match.Groups["duration"].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double duration);
                message.Duration = duration;
                Int32.TryParse(match.Groups["entindex"].Value, out int entindex);
                message.Entindex = entindex;

                return message;
            }
            return null;
        }
    }
}