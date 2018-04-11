namespace Vgbot.Core.Messages
{
    public class RoundScoredMessage : IMessage
    {
        public string Team { get; set; }
        public string Type { get; set; }
        public int ScoreCT { get; set; }
        public int ScoreT { get; set; }
    }
}
