using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundEndRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Round_End\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundEndMessage abstractMessage = new RoundEndMessage();
                //var match = regex.Match(input);
                                                                     
                return abstractMessage;
            }
            return null;
        }
    }
}