using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class GameOverRegex : IRegex
    {
        private static readonly string pattern = "Game Over: (?<gameMode>.+)  (?<map>.+) score (?<score>\\d+.\\d+) after (?<duration>\\d+) min";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new GameOverMessage();
                var match = regex.Match(input);
                message.GameMode = match.Groups["gameMode"].Value;
                message.Map = match.Groups["map"].Value;
                message.Score = match.Groups["score"].Value;
                int.TryParse(match.Groups["duration"].Value, out int duration);
                message.Duration = duration;

                return message;
            }
            return null;
        }
    }
}