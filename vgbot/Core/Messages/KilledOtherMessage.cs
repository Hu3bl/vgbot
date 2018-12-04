using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class KilledOtherMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public int UserPosX { get; set; }
        public int UserPosY { get; set; }
        public int UserPosZ { get; set; }
        public string KilledOtherID { get; set; }
        public string KilledOtherName { get; set; }
        public int KilledUserPosX { get; set; }
        public int KilledUserPosY { get; set; }
        public int KilledUserPosZ { get; set; }
        public string Weapon { get; set; }
        public bool IsHeadshot { get; set; }
        public bool IsPenetrated { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
