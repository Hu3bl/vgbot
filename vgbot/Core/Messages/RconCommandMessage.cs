using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class RconCommandMessage : AbstractMessage
    {
        public string From { get; set; }
        public string Command { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
