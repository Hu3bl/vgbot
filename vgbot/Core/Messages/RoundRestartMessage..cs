using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class RoundRestartAbstractMessage : AbstractMessage
    {
        public int Seconds { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}