using System;
using System.Collections.Generic;
using System.Text;

namespace vgbot.Model.Events
{
    class Attack : RoundEvent
    {
        public Player Attacker { get; }
        public Player Victim { get; }
        public int Damage { get; }
        public string Weapon { get; }
        
        public Attack(Player attacker, Player victim, int damage, string weapon)
        {
            Attacker = attacker;
            Victim = victim;
            Damage = damage;
            Weapon = weapon;
        }
    }
}
