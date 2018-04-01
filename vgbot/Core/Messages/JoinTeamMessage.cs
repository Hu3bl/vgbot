namespace Vgbot.Core.Messages
{
    public class JoinTeamMessage : IMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string JoinedTeam { get; set; }
    }
}
