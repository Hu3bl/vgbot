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

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                KillMessage abstractMessage = new KillMessage();
                var match = regex.Match(input);
                abstractMessage.UserName = match.Groups["userName"].Value;
                abstractMessage.UserID = match.Groups["userId"].Value;
                abstractMessage.UserSteamID = match.Groups["userSteamId"].Value;
                abstractMessage.UserTeam = match.Groups["userTeam"].Value;
                Int32.TryParse(match.Groups["userPosX"].Value, out int userPosX);
                abstractMessage.UserPosX = userPosX;
                Int32.TryParse(match.Groups["userPosY"].Value, out int userPosY);
                abstractMessage.UserPosY = userPosY;
                Int32.TryParse(match.Groups["userPosZ"].Value, out int userPosZ);
                abstractMessage.UserPosZ = userPosZ;
                abstractMessage.KilledUserName = match.Groups["killedUserName"].Value;
                abstractMessage.KilledUserID = match.Groups["killedUserId"].Value;
                abstractMessage.KilledUserSteamID = match.Groups["killedSteamId"].Value;
                abstractMessage.KilledUserTeam = match.Groups["killedUserTeam"].Value;
                Int32.TryParse(match.Groups["killedPosX"].Value, out int killedPosX);
                abstractMessage.KilledUserPosX = killedPosX;
                Int32.TryParse(match.Groups["killedPosY"].Value, out int killedPosY);
                abstractMessage.KilledUserPosY = killedPosY;
                Int32.TryParse(match.Groups["killedPosZ"].Value, out int killedPosZ);
                abstractMessage.KilledUserPosZ = killedPosZ;
                abstractMessage.Weapon = match.Groups["weapon"].Value;

                Regex headshotRegex = new Regex(headshotPattern);
                if(headshotRegex.IsMatch(match.Groups["headshotOrPenetrated"].Value))
                {
                    abstractMessage.IsHeadshot = true;
                }
                else
                {
                    abstractMessage.IsHeadshot = false;
                }
                                
                Regex penetratedRegex = new Regex(penetratedPattern);
                if(penetratedRegex.IsMatch(match.Groups["headshotOrPenetrated"].Value))
                {
                    abstractMessage.IsPenetrated = true;
                }
                else
                {
                    abstractMessage.IsPenetrated = false;
                }
                                                                     
                return abstractMessage;
            }
            return null;
        }
    }
}