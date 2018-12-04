﻿using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class KilledByTheBombMessage : AbstractMessage
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserTeam { get; set; }
        public string UserSteamID { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int PosZ { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}
