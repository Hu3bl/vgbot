using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RoundStartRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Round_Start\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RoundStartMessage message = new RoundStartMessage();
                var match = regex.Match(input);
                
                return message;
            }
            return null;
        }
    }
}