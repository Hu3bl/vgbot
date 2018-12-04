using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class ThrewStuffRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\""
			+ " threw (?<stuff>hegrenade|flashbang|smokegrenade|decoy|molotov) \\[(?<posX>[\\-]?[0-9]+) (?<posY>[\\-]?[0-9]+) (?<posZ>[\\-]?[0-9]+)\\]( flashbang entindex (?<entindex>\\d+))?";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                ThrewStuffMessage abstractMessage = new ThrewStuffMessage();
                var match = regex.Match(input);
                abstractMessage.UserName = match.Groups["userName"].Value;
                abstractMessage.UserID = match.Groups["userId"].Value;
                abstractMessage.UserSteamID = match.Groups["userSteamId"].Value;
                abstractMessage.UserTeam = match.Groups["userTeam"].Value;
                abstractMessage.Stuff = match.Groups["stuff"].Value;
                Int32.TryParse(match.Groups["posX"].Value, out int posX);
                abstractMessage.PosX = posX;
                Int32.TryParse(match.Groups["posY"].Value, out int posY);
                abstractMessage.PosY = posY;
                Int32.TryParse(match.Groups["posZ"].Value, out int posZ);
                abstractMessage.PosZ = posZ;
                if(match.Groups["entindex"].Value != string.Empty)
                {
                    Int32.TryParse(match.Groups["entindex"].Value, out int entindex);
                    abstractMessage.EntIndex = entindex;
                }
                
                return abstractMessage;
            }
            return null;
        }
    }
}