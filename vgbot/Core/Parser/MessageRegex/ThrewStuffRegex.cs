using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class ThrewStuffRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\""
			+ " threw (?<stuff>hegrenade|flashbang|smokegrenade|decoy|molotov) \\[(?<posX>[\\-]?[0-9]+) (?<posY>[\\-]?[0-9]+) (?<posZ>[\\-]?[0-9]+)\\]";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                ThrewStuffMessage message = new ThrewStuffMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.Stuff = match.Groups["stuff"].Value;
                Int32.TryParse(match.Groups["posX"].Value, out int posX);
                message.PosX = posX;
                Int32.TryParse(match.Groups["posY"].Value, out int posY);
                message.PosY = posY;
                Int32.TryParse(match.Groups["posZ"].Value, out int posZ);
                message.PosZ = posZ;
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}