using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class KillAssistMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string KilledUserID { get; set; }
        public string KilledUserName { get; set; }
        public string KilledUserTeam { get; set; }
        public string KilledUserSteamID { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
