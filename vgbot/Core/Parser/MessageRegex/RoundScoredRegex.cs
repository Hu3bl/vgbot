using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>.*)\" triggered \"SFUI_Notice_(?<type>Terrorists_Win|CTs_Win|Target_Bombed|Target_Saved|Bomb_Defused)\" \\(CT \"(?<ct>\\d+)\"\\) \\(T \"(?<t>\\d+)\"\\)";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundScoredMessage message = new RoundScoredMessage();
                var match = regex.Match(input);
                message.Team = match.Groups["team"].Value;
                message.Type = match.Groups["type"].Value;
                int.TryParse(match.Groups["ct"].Value, out int scoreCT);
                message.ScoreCT = scoreCT;
                int.TryParse(match.Groups["t"].Value, out int scoreT);
                message.ScoreT = scoreT;

                return message;
            }
            return null;
        }
    }
}