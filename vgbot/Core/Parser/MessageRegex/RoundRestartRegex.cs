using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundRestartRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Restart_Round_\\((?<seconds>\\d+)_(second|seconds)\\)\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundRestartMessage message = new RoundRestartMessage();
                var match = regex.Match(input);
                int.TryParse(match.Groups["seconds"].Value, out int seconds);
                message.Seconds = seconds;

                return message;
            }
            return null;
        }
    }
}