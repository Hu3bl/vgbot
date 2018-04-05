using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundEndRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Round_End\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                RoundEndMessage message = new RoundEndMessage();
                var match = regex.Match(input);
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}