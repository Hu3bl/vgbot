namespace Vgbot.Core.Messages
{
    public class RconCommandMessage : IMessage
    {
        public string From { get; set; }
        public string Command { get; set; }
    }
}
