using Vgbot.Core.Messages;

namespace vgbot.Model.Events
{
    class Kill : RoundEvent
    {
        public Player Killer { get; }
        public Player Victim { get; }
        public string Weapon { get; }
        public eKillType Type { get; }

        public Kill(Player killer, Player victim, string weapon, eKillType type)
        {
            Killer = killer;
            Victim = victim;
            Weapon = weapon;
            Type = type;
        }
    }
}
