using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class ChangeMapRegex : IRegex
    {
        private static readonly string pattern = "(?<type>Started map|Loading map) \"(?<map>.*)\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                ChangeMapMessage message = new ChangeMapMessage();
                var match = regex.Match(input);
                message.Type = match.Groups["type"].Value;
                message.Map = match.Groups["map"].Value;
                                      
                return message;
            }
            return null;   
        }
    }
}