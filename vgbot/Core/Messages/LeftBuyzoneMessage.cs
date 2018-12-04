using System.Collections.Generic;
using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class LeftBuyzoneMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public IList<string> Objects { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
