using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public interface IRegex
    {
        IMessage Parse(string input);
    }
}
