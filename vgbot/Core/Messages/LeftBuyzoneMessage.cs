using System.Collections.Generic;

namespace Vgbot.Core.Messages
{
    public class LeftBuyzoneMessage : IMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public IList<string> Objects { get; set; }
    }
}
