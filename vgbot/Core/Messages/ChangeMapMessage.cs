namespace Vgbot.Core.Messages
{
    public class ChangeMapMessage : IMessage
    {
        public string Type { get; set; }
        public string Map { get; set; }
    }
}