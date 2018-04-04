using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class KillRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "\\[(?<userPosX>[\\-]?[0-9]+) (?<userPosY>[\\-]?[0-9]+) (?<userPosZ>[\\-]?[0-9]+)\\] "
			+ "killed \"(?<killedUserName>.+)[<](?<killedUserId>\\d+)[>][<](?<killedSteamId>.*)[>][<](?<killedUserTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
			+ "\\[(?<killedPosX>[\\-]?[0-9]+) (?<killedPosY>[\\-]?[0-9]+) (?<killedPosZ>[\\-]?[0-9]+)\\] "
			+ "with \"(?<weapon>[a-zA-Z0-9_]+)\"(?<headshotOrPenetrated>.*)";

        private static readonly string headshotPattern = "\\(.*headshot.*\\)";
	    private static readonly string penetratedPattern = "\\(.*penetrated.*\\)";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                KillMessage message = new KillMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups[1].Value;
                message.UserID = match.Groups[2].Value;
                message.UserSteamID = match.Groups[3].Value;
                message.UserTeam = match.Groups[4].Value;
                Int32.TryParse(match.Groups[5].Value, out int userPosX);
                message.UserPosX = userPosX;
                Int32.TryParse(match.Groups[6].Value, out int userPosY);
                message.UserPosY = userPosY;
                Int32.TryParse(match.Groups[7].Value, out int userPosZ);
                message.UserPosZ = userPosZ;
                message.KilledUserName = match.Groups[8].Value;
                message.KilledUserID = match.Groups[9].Value;
                message.KilledUserSteamID = match.Groups[10].Value;
                message.KilledUserTeam = match.Groups[11].Value;
                Int32.TryParse(match.Groups[12].Value, out int killedPosX);
                message.KilledUserPosX = killedPosX;
                Int32.TryParse(match.Groups[13].Value, out int killedPosY);
                message.KilledUserPosY = killedPosY;
                Int32.TryParse(match.Groups[14].Value, out int killedPosZ);
                message.KilledUserPosZ = killedPosZ;
                message.Weapon = match.Groups[15].Value;

                Regex headshotRegex = new Regex(headshotPattern);
                if(headshotRegex.IsMatch(match.Groups[16].Value))
                {
                    message.IsHeadshot = true;
                }
                else
                {
                    message.IsHeadshot = false;
                }
                                
                Regex penetratedRegex = new Regex(penetratedPattern);
                if(penetratedRegex.IsMatch(match.Groups[16].Value))
                {
                    message.IsPenetrated = true;
                }
                else
                {
                    message.IsPenetrated = false;
                }
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}