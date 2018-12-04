using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundScoredRegex : IRegex
    {
        private static readonly string pattern = "Team \"(?<team>.*)\" triggered \"SFUI_Notice_(?<type>Terrorists_Win|CTs_Win|Target_Bombed|Target_Saved|Bomb_Defused)\" \\(CT \"(?<ct>\\d+)\"\\) \\(T \"(?<t>\\d+)\"\\)";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundScoredMessage abstractMessage = new RoundScoredMessage();
                var match = regex.Match(input);
                abstractMessage.Team = match.Groups["team"].Value;
                abstractMessage.Type = match.Groups["type"].Value;
                int.TryParse(match.Groups["ct"].Value, out int scoreCT);
                abstractMessage.ScoreCT = scoreCT;
                int.TryParse(match.Groups["t"].Value, out int scoreT);
                abstractMessage.ScoreT = scoreT;

                return abstractMessage;
            }
            return null;
        }
    }
}