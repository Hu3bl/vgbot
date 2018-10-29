using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundEndRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Round_End\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundEndMessage message = new RoundEndMessage();
                //var match = regex.Match(input);
                                                                     
                return message;
            }
            return null;
        }
    }
}