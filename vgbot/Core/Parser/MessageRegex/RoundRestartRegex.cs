using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundRestartRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Restart_Round_\\((\\d+)_(second|seconds)\\)\"!";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                RoundRestartMessage message = new RoundRestartMessage();
                var match = regex.Match(input);
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}