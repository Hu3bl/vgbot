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
        
        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                AttackedMessage message = new AttackedMessage();
                var match = regex.Match(input);
                message.AttackerName = match.Groups["attackerName"].Value;
                message.AttackerUserID = match.Groups["attackerUserId"].Value;
                message.AttackerSteamID = match.Groups["attackerSteamId"].Value;
                message.AttackerTeam = match.Groups["attackerTeam"].Value;
                Int32.TryParse(match.Groups["attackerPosX"].Value, out int attackerPosX);
                message.AttackerPosX = attackerPosX;
                Int32.TryParse(match.Groups["attackerPosY"].Value, out int attackerPosY);
                message.AttackerPosY = attackerPosY;
                Int32.TryParse(match.Groups["attackerPosZ"].Value, out int attackerPosZ);
                message.AttackerPosZ = attackerPosZ;
                message.VictimName = match.Groups["victimName"].Value;
                message.VictimUserID = match.Groups["victimUserId"].Value;
                message.VictimSteamID = match.Groups["victimSteamId"].Value;
                message.VictimTeam = match.Groups["victimTeam"].Value;
                Int32.TryParse(match.Groups["victimPosX"].Value, out int victimPosX);
                message.VictimPosX = victimPosX;
                Int32.TryParse(match.Groups["victimPosY"].Value, out int victimPosY);
                message.VictimPosY = victimPosY;
                Int32.TryParse(match.Groups["victimPosZ"].Value, out int victimPosZ);
                message.VictimPosZ = victimPosZ;
                message.AttackerWeapon = match.Groups["attackerWeapon"].Value;
                Int32.TryParse(match.Groups["attackerDamage"].Value, out int attackerDamage);
                message.AttackerDamage = attackerDamage;
                Int32.TryParse(match.Groups["attackerDamageArmor"].Value, out int attackerDamageArmor);
                message.AttackerDamageArmor = attackerDamageArmor;
                Int32.TryParse(match.Groups["victimHealth"].Value, out int victimHealth);
                message.VictimHealth = victimHealth;
                Int32.TryParse(match.Groups["victimArmor"].Value, out int victimArmor);
                message.VictimArmor = victimArmor;
                message.AttackerHitGroup = match.Groups["attackerHitGroup"].Value;

                return message;
            }
            return null;          
        }
    }
}