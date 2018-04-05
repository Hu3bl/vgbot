using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>.*)\" triggered \"SFUI_Notice_(?<type>Terrorists_Win|CTs_Win|Target_Bombed|Target_Saved|Bomb_Defused)";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                RoundScoredMessage message = new RoundScoredMessage();
                var match = regex.Match(input);
                message.Team = match.Groups["team"].Value;
                message.Type = match.Groups["type"].Value;
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}