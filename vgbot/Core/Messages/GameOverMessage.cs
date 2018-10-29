namespace Vgbot.Core.Messages
{
    public class GameOverMessage : IMessage
    {
        public string GameMode { get; set; }
        public string Map { get; set; }
        public string Score { get; set; }
        public int Duration { get; set; }
    }
}