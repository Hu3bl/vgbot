using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class ChangeNameMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string NewUserName { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
