namespace Vgbot.Core.Messages
{
    public class TeamScoredMessage : IMessage
    {
        public string Team { get; set; }
        public string Score { get; set; }
        public string Players { get; set; }
    }
}
