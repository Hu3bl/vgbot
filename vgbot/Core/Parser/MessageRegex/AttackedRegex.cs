using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class AttackedRegex : IRegex
    {
        private static readonly string pattern = "\"(?<attackerName>.*)[<](?<attackerUserId>\\d+)[>][<](?<attackerSteamId>.*)[>][<](?<attackerTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "\\[(?<attackerPosX>[\\-]?[0-9]+) (?<attackerPosY>[\\-]?[0-9]+) (?<attackerPosZ>[\\-]?[0-9]+)\\] attacked "
			+ "\"(?<victimName>.*)[<](?<victimUserId>\\d+)[>][<](?<victimSteamId>.*)[>][<](?<victimTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "\\[(?<victimPosX>[\\-]?[0-9]+) (?<victimPosY>[\\-]?[0-9]+) (?<victimPosZ>[\\-]?[0-9]+)\\] with \"(?<attackerWeapon>[a-zA-Z0-9_]+)\" "
			+ "\\(damage \"(?<attackerDamage>[0-9]+)\"\\) \\(damage_armor \"(?<attackerDamageArmor>[0-9]+)\"\\) \\(health \"(?<victimHealth>[0-9]+)\"\\) "
			+ "\\(armor \"(?<victimArmor>[0-9]+)\"\\) \\(hitgroup \"(?<attackerHitGroup>.*)\"\\)";
        
        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                AttackedMessage abstractMessage = new AttackedMessage();
                var match = regex.Match(input);
                abstractMessage.AttackerName = match.Groups["attackerName"].Value;
                abstractMessage.AttackerUserID = match.Groups["attackerUserId"].Value;
                abstractMessage.AttackerSteamID = match.Groups["attackerSteamId"].Value;
                abstractMessage.AttackerTeam = match.Groups["attackerTeam"].Value;
                Int32.TryParse(match.Groups["attackerPosX"].Value, out int attackerPosX);
                abstractMessage.AttackerPosX = attackerPosX;
                Int32.TryParse(match.Groups["attackerPosY"].Value, out int attackerPosY);
                abstractMessage.AttackerPosY = attackerPosY;
                Int32.TryParse(match.Groups["attackerPosZ"].Value, out int attackerPosZ);
                abstractMessage.AttackerPosZ = attackerPosZ;
                abstractMessage.VictimName = match.Groups["victimName"].Value;
                abstractMessage.VictimUserID = match.Groups["victimUserId"].Value;
                abstractMessage.VictimSteamID = match.Groups["victimSteamId"].Value;
                abstractMessage.VictimTeam = match.Groups["victimTeam"].Value;
                Int32.TryParse(match.Groups["victimPosX"].Value, out int victimPosX);
                abstractMessage.VictimPosX = victimPosX;
                Int32.TryParse(match.Groups["victimPosY"].Value, out int victimPosY);
                abstractMessage.VictimPosY = victimPosY;
                Int32.TryParse(match.Groups["victimPosZ"].Value, out int victimPosZ);
                abstractMessage.VictimPosZ = victimPosZ;
                abstractMessage.AttackerWeapon = match.Groups["attackerWeapon"].Value;
                Int32.TryParse(match.Groups["attackerDamage"].Value, out int attackerDamage);
                abstractMessage.AttackerDamage = attackerDamage;
                Int32.TryParse(match.Groups["attackerDamageArmor"].Value, out int attackerDamageArmor);
                abstractMessage.AttackerDamageArmor = attackerDamageArmor;
                Int32.TryParse(match.Groups["victimHealth"].Value, out int victimHealth);
                abstractMessage.VictimHealth = victimHealth;
                Int32.TryParse(match.Groups["victimArmor"].Value, out int victimArmor);
                abstractMessage.VictimArmor = victimArmor;
                abstractMessage.AttackerHitGroup = match.Groups["attackerHitGroup"].Value;

                return abstractMessage;
            }
            return null;          
        }
    }
}