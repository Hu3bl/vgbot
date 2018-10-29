using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RconCommandRegex : IRegex
    {
        private static readonly string pattern = "rcon from \"(?<from>.+)\": command \"(?<command>.*)\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RconCommandMessage message = new RconCommandMessage();
                var match = regex.Match(input);
                message.From = match.Groups["from"].Value;
                message.Command = match.Groups["command"].Value;
                                                                     
                return message;
            }
            return null;
        }
    }
}