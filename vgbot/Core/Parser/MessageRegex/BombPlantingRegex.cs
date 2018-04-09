using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class BombPlantingRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" triggered \"Planted_The_Bomb\"";
        
        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                BombPlantingMessage message = new BombPlantingMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                                
                outMessage = message;
            }
            return isMatch;   		
        }
    }
}