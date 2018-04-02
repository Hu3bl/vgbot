using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public interface IRegex
    {
        bool TryParse(string input, out IMessage outMessage);
    }
}
