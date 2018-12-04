using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class RconCommandRegex : IRegex
    {
        private static readonly string pattern = "rcon from \"(?<from>.+)\": command \"(?<command>.*)\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                RconCommandMessage abstractMessage = new RconCommandMessage();
                var match = regex.Match(input);
                abstractMessage.From = match.Groups["from"].Value;
                abstractMessage.Command = match.Groups["command"].Value;
                                                                     
                return abstractMessage;
            }
            return null;
        }
    }
}