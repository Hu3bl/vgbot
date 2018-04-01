namespace Vgbot.Core.Messages
{
    public class PurchasedMessage : IMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string PurchasedObject { get; set; }
    }
}
