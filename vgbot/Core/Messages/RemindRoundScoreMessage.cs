namespace Vgbot.Core.Messages
{
    public class RemindRoundScoreMessage : IMessage
    {
        public string Team { get; set; }
        public string TeamWin { get; set; }
        public string Type { get; set; }
    }
}
