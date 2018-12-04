using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class RoundScoredMessage : AbstractMessage
    {
        public string Team { get; set; }
        public string Type { get; set; }
        public int ScoreCT { get; set; }
        public int ScoreT { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
