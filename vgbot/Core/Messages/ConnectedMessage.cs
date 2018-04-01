namespace Vgbot.Core.Messages
{
    public class ConnectedMessage : IMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserSteamID { get; set; }
        public string Address { get; set; }
    }
}
