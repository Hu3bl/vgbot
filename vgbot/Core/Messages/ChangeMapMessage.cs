using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class ChangeMapMessage : AbstractMessage
    {
        public string Type { get; set; }
        public string Map { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}