using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public interface IRegex
    {
        IMessage TryParse(string input);
    }
}
