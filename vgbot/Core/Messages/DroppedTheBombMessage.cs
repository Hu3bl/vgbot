namespace Vgbot.Core.Messages
{
    public class DroppedTheBombMessage : IMessage
    {
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public string UserID { get; set; }
    }    
}