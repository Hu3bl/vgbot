using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class GameOverMessage : AbstractMessage
    {
        public string GameMode { get; set; }
        public string Map { get; set; }
        public string Score { get; set; }
        public int Duration { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}