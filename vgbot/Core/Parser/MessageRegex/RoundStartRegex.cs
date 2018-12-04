using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundStartRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Round_Start\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundStartMessage abstractMessage = new RoundStartMessage();
                var match = regex.Match(input);
                
                return abstractMessage;
            }
            return null;
        }
    }
}