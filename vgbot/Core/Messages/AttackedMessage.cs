
using vgbot.Model;
using vgbot.Model.Events;

namespace Vgbot.Core.Messages
{
    public class AttackedMessage : AbstractMessage
    {
        public string AttackerName { get; set; }
        public string AttackerUserID { get; set; }
        public string AttackerSteamID { get; set; }
        public string AttackerTeam { get; set; }
        public int AttackerPosX { get; set; }
        public int AttackerPosY { get; set; }
        public int AttackerPosZ { get; set; }
        public string AttackerWeapon { get; set; }
        public int AttackerDamage { get; set; }
        public int AttackerDamageArmor { get; set; }
        public string AttackerHitGroup { get; set; }
        public string VictimName { get; set; }
        public string VictimUserID { get; set; }
        public string VictimSteamID { get; set; }
        public string VictimTeam { get; set; }
        public int VictimPosX { get; set; }
        public int VictimPosY { get; set; }
        public int VictimPosZ { get; set; }
        public int VictimHealth { get; set; }
        public int VictimArmor { get; set; }

        public override void Process(Match match)
        {
            var round = match.GetCurrentRound();
            var damage = new Attack(match.GetPlayerWithId(AttackerSteamID), match.GetPlayerWithId(VictimSteamID),
                AttackerDamage, AttackerWeapon);
            round.RoundEvents.Add(damage);
        }
    }
}