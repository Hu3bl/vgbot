using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class TeamScoredMessage : AbstractMessage
    {
        public string Team { get; set; }
        public string Score { get; set; }
        public string Players { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
