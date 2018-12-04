using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class ConnectedMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserSteamID { get; set; }
        public string Address { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
