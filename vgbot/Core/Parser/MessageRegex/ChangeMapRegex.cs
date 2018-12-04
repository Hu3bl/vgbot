using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class ChangeMapRegex : IRegex
    {
        private static readonly string pattern = "(?<type>Started map|Loading map) \"(?<map>.*)\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                ChangeMapMessage abstractMessage = new ChangeMapMessage();
                var match = regex.Match(input);
                abstractMessage.Type = match.Groups["type"].Value;
                abstractMessage.Map = match.Groups["map"].Value;
                                      
                return abstractMessage;
            }
            return null;   
        }
    }
}