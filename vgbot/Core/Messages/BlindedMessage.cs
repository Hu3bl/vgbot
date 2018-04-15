
namespace Vgbot.Core.Messages
{
    public class BlindedMessage : IMessage
    {
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string UserID { get; set; }
        public string VictimUserName { get; set; }
        public string VictimUserID { get; set; }
        public string VictimUserSteamID { get; set; }
        public string VictimUserTeam { get; set; }
        public double Duration { get; set; }
        public int Entindex { get; set; }
    }
}