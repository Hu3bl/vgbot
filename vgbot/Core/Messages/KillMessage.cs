namespace Vgbot.Core.Messages
{
    public class KillMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public int UserPosX { get; set; }
        public int UserPosY { get; set; }
        public int UserPosZ { get; set; }
        public string KilledUserID { get; set; }
        public string KilledUserName { get; set; }
        public string KilledUserTeam { get; set; }
        public string KilledUserSteamID { get; set; }
        public int KilledUserPosX { get; set; }
        public int KilledUserPosY { get; set; }
        public int KilledUserPosZ { get; set; }
        public string Weapon { get; set; }
        public bool IsHeadshot { get; set; }
        public bool IsPenetrated { get; set; }
    }
}
