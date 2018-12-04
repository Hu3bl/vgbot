
using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class MolotovSpawnedMessage : AbstractMessage
    {
        public string PosX { get; set; }
        public string PosY { get; set; }
        public string PosZ { get; set; }
        public string VelocityX { get; set; }
        public string VelocityY { get; set; }
        public string VelocityZ { get; set; }

        public override void Process(Match match)
        {
            
        }
    }
}