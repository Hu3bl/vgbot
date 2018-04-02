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
        
        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                AttackedMessage message = new AttackedMessage();
                var match = regex.Match(input);
                message.AttackerName = match.Groups[1].Value;
                message.AttackerUserID = match.Groups[2].Value;
                message.AttackerSteamID = match.Groups[3].Value;
                message.AttackerTeam = match.Groups[4].Value;
                Int32.TryParse(match.Groups[5].Value, out int attackerPosX);
                message.AttackerPosX = attackerPosX;
                Int32.TryParse(match.Groups[6].Value, out int attackerPosY);
                message.AttackerPosY = attackerPosY;
                Int32.TryParse(match.Groups[7].Value, out int attackerPosZ);
                message.AttackerPosZ = attackerPosZ;
                message.VictimName = match.Groups[8].Value;
                message.VictimUserID = match.Groups[9].Value;
                message.VictimSteamID = match.Groups[10].Value;
                message.VictimTeam = match.Groups[11].Value;
                Int32.TryParse(match.Groups[12].Value, out int victimPosX);
                message.VictimPosX = victimPosX;
                Int32.TryParse(match.Groups[13].Value, out int victimPosY);
                message.VictimPosY = victimPosY;
                Int32.TryParse(match.Groups[14].Value, out int victimPosZ);
                message.VictimPosZ = victimPosZ;
                message.AttackerWeapon = match.Groups[15].Value;
                Int32.TryParse(match.Groups[16].Value, out int attackerDamage);
                message.AttackerDamage = attackerDamage;
                Int32.TryParse(match.Groups[17].Value, out int attackerDamageArmor);
                message.AttackerDamageArmor = attackerDamageArmor;
                Int32.TryParse(match.Groups[18].Value, out int victimHealth);
                message.VictimHealth = victimHealth;
                Int32.TryParse(match.Groups[19].Value, out int victimArmor);
                message.VictimArmor = victimArmor;
                message.AttackerHitGroup = match.Groups[20].Value;

                outMessage = message;
            }
            return isMatch;          
        }
    }
}