namespace Vgbot.Core.Messages
{
    public class EnteredTheGameMessage : IMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserSteamID { get; set; }
    }
}
