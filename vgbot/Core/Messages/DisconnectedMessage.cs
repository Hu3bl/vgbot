namespace Vgbot.Core.Messages
{
    public class DisconnectedMessage : IMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string Reason { get; set; }
    }
}
