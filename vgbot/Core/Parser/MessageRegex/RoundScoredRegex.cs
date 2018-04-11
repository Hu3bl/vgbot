using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>.*)\" triggered \"SFUI_Notice_(?<type>Terrorists_Win|CTs_Win|Target_Bombed|Target_Saved|Bomb_Defused)\" \\(CT \"(?<ct>\\d+)\"\\) \\(T \"(?<t>\\d+)\"\\)";

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
                Int32.TryParse(match.Groups["ct"].Value, out int scoreCT);
                message.ScoreCT = scoreCT;
                Int32.TryParse(match.Groups["t"].Value, out int scoreT);
                message.ScoreT = scoreT;
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}