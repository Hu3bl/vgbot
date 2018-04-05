using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class TeamScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>CT|TERRORIST)\" scored \"(?<score>\\d+)\" with \"(?<players>\\d+)\" players";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                TeamScoredMessage message = new TeamScoredMessage();
                var match = regex.Match(input);
                message.Team = match.Groups["team"].Value;
                message.Score = match.Groups["score"].Value;
                message.Players = match.Groups["players"].Value;
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}