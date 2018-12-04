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
       
        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                BlindedMessage abstractMessage = new BlindedMessage();
                var match = regex.Match(input);
                abstractMessage.UserName = match.Groups["userName"].Value;
                abstractMessage.UserID = match.Groups["userId"].Value;
                abstractMessage.UserSteamID = match.Groups["userSteamId"].Value;
                abstractMessage.UserTeam = match.Groups["userTeam"].Value;
                abstractMessage.VictimUserName = match.Groups["victimUserName"].Value;
                abstractMessage.VictimUserID = match.Groups["victimUserId"].Value;
                abstractMessage.VictimUserSteamID = match.Groups["victimUserSteamId"].Value;
                abstractMessage.VictimUserTeam = match.Groups["victimUserTeam"].Value;
                Double.TryParse(match.Groups["duration"].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double duration);
                abstractMessage.Duration = duration;
                Int32.TryParse(match.Groups["entindex"].Value, out int entindex);
                abstractMessage.EntIndex = entindex;

                return abstractMessage;
            }
            return null;
        }
    }
}