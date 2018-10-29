using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class SwitchTeamRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>]\" switched from team [<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>] to [<](?<switchedTeam>CT|TERRORIST|Unassigned|Spectator)[>]";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                SwitchTeamMessage message = new SwitchTeamMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.SwitchedTeam = match.Groups["switchedTeam"].Value;
                
                return message;
            }
            return null;
        }
    }
}