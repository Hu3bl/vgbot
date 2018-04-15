
namespace Vgbot.Core.Messages
{
    public class MolotovSpawnedMessage : IMessage
    {
        public string PosX { get; set; }
        public string PosY { get; set; }
        public string PosZ { get; set; }
        public string VelocityX { get; set; }
        public string VelocityY { get; set; }
        public string VelocityZ { get; set; }
    }
}