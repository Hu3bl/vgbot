using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class TeamScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>CT|TERRORIST)\" scored \"(?<score>\\d+)\" with \"(?<players>\\d+)\" players";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                TeamScoredMessage abstractMessage = new TeamScoredMessage();
                var match = regex.Match(input);
                abstractMessage.Team = match.Groups["team"].Value;
                abstractMessage.Score = match.Groups["score"].Value;
                abstractMessage.Players = match.Groups["players"].Value;
                
                return abstractMessage;
            }
            return null;
        }
    }
}