using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class SwitchTeamRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>]\" switched from team [<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>] to [<](?<switchedTeam>CT|TERRORIST|Unassigned|Spectator)[>]";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                SwitchTeamMessage message = new SwitchTeamMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.SwitchedTeam = match.Groups["switchedTeam"].Value;
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}