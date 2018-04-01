using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class AttackedRegex : IRegex
    {
        private static string pattern = "\"(?<attackerName>.*)[<](?<attackerUserId>\\d+)[>][<](?<attackerSteamId>.*)[>][<](?<attackerTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "\\[(?<attackerPosX>[\\-]?[0-9]+) (?<attackerPosY>[\\-]?[0-9]+) (?<attackerPosZ>[\\-]?[0-9]+)\\] attacked "
			+ "\"(?<victimName>.*)[<](?<victimUserId>\\d+)[>][<](?<victimSteamId>.*)[>][<](?<victimTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "\\[(?<victimPosX>[\\-]?[0-9]+) (?<victimPosY>[\\-]?[0-9]+) (?<victimPosZ>[\\-]?[0-9]+)\\] with \"(?<attackerWeapon>[a-zA-Z0-9_]+)\" "
			+ "\\(damage \"(?<attackerDamage>[0-9]+)\"\\) \\(damage_armor \"(?<attackerDamageArmor>[0-9]+)\"\\) \\(health \"(?<victimHealth>[0-9]+)\"\\) "
			+ "\\(armor \"(?<victimArmor>[0-9]+)\"\\) \\(hitgroup \"(?<attackerHitGroup>.*)\"\\)";
        public IMessage TryParse(string input)
        {
            Regex regex = new Regex(pattern);
            return new AttackedMessage();            
        }
    }
}