using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class MatchStartRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Match_Start\" on \"(?<map>.+)\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new MatchStartMessage();
                var match = regex.Match(input);
                message.Map = match.Groups["map"].Value;

                return message;
            }
            return null;
        }
    }
}