using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class TeamPlaySideRegex : IRegex
    {
        private static readonly string pattern = "Team playing \"(?<side>CT|TERRORIST|Unassigned|Spectator)\": (?<teamName>.*)";
        
        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new TeamPlaySideMessage();
                var match = regex.Match(input);
                message.Side = match.Groups["side"].Value;
                message.TeamName = match.Groups["teamName"].Value;

                return message;
            }
            return null;
        }
    }
}