using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class SayTeamRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" say_team \"(?<text>.*)\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                SayTeamMessage message = new SayTeamMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.Text = match.Groups["text"].Value;
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}