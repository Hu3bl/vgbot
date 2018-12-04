using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class StartingFreezePeriodRegex : IRegex
    {
        private static readonly string pattern = "Starting Freeze period";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new StartingFreezePeriodMessage();
                var match = regex.Match(input);

                return message;
            }
            return null;
        }
    }
}