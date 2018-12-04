using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public interface IRegex
    {
        AbstractMessage Parse(string input);
    }
}
