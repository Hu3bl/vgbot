using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RconCommandRegex : IRegex
    {
        private static readonly string pattern = "rcon from \"(?<from>.+)\": command \"(?<command>.*)\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                RconCommandMessage message = new RconCommandMessage();
                var match = regex.Match(input);
                message.From = match.Groups["from"].Value;
                message.Command = match.Groups["command"].Value;
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}