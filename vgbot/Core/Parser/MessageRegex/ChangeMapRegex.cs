using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class ChangeMapRegex : IRegex
    {
        private static readonly string pattern = "(?<type>Started map|Loading map) \"(?<map>.*)\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                ChangeMapMessage message = new ChangeMapMessage();
                var match = regex.Match(input);
                message.Type = match.Groups["type"].Value;
                message.Map = match.Groups["map"].Value;
                                      
                outMessage = message;
            }
            return isMatch;   
        }
    }
}