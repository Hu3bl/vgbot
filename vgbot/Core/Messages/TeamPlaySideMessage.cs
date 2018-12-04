using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class TeamPlaySideMessage : AbstractMessage
    {
        public string Side { get; set; }
        public string TeamName { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
