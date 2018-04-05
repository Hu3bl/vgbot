using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundStartRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Round_Start\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                RoundStartMessage message = new RoundStartMessage();
                var match = regex.Match(input);
                
                outMessage = message;
            }
            return isMatch;
        }
    }
}