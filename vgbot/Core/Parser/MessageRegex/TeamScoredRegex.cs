using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class TeamScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>CT|TERRORIST)\" scored \"(?<score>\\d+)\" with \"(?<players>\\d+)\" players";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                TeamScoredMessage message = new TeamScoredMessage();
                var match = regex.Match(input);
                message.Team = match.Groups["team"].Value;
                message.Score = match.Groups["score"].Value;
                message.Players = match.Groups["players"].Value;
                
                return message;
            }
            return null;
        }
    }
}