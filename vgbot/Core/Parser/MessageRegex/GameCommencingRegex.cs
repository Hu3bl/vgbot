using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class GameCommencingRegex : IRegex
    {
        private static readonly string pattern = "World triggered \"Game_Commencing\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new GameCommencingMessage();
                
                return message;
            }
            return null;
        }
    }
}