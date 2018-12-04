using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class SayMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string Text { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
