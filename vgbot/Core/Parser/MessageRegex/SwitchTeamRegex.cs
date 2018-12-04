using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class SwitchTeamRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>]\" switched from team [<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>] to [<](?<switchedTeam>CT|TERRORIST|Unassigned|Spectator)[>]";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                SwitchTeamMessage abstractMessage = new SwitchTeamMessage();
                var match = regex.Match(input);
                abstractMessage.UserName = match.Groups["userName"].Value;
                abstractMessage.UserID = match.Groups["userId"].Value;
                abstractMessage.UserSteamID = match.Groups["userSteamId"].Value;
                abstractMessage.UserTeam = match.Groups["userTeam"].Value;
                abstractMessage.SwitchedTeam = match.Groups["switchedTeam"].Value;
                
                return abstractMessage;
            }
            return null;
        }
    }
}