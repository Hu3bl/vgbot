using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class KilledOtherRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" "
            + "\\[(?<userPosX>[\\-]?[0-9]+) (?<userPosY>[\\-]?[0-9]+) (?<userPosZ>[\\-]?[0-9]+)\\] "
            + "killed other \"(?<killedOtherName>.+)[<](?<killedOtherId>\\d+)[>]\" "
            + "\\[(?<killedPosX>[\\-]?[0-9]+) (?<killedPosY>[\\-]?[0-9]+) (?<killedPosZ>[\\-]?[0-9]+)\\] "
            + "with \"(?<weapon>[a-zA-Z0-9_]+)\"(?<headshotOrPenetrated>.*)";

        private static readonly string headshotPattern = "\\(.*headshot.*\\)";
        private static readonly string penetratedPattern = "\\(.*penetrated.*\\)";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new KilledOtherMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                Int32.TryParse(match.Groups["userPosX"].Value, out int userPosX);
                message.UserPosX = userPosX;
                Int32.TryParse(match.Groups["userPosY"].Value, out int userPosY);
                message.UserPosY = userPosY;
                Int32.TryParse(match.Groups["userPosZ"].Value, out int userPosZ);
                message.UserPosZ = userPosZ;
                message.KilledOtherName = match.Groups["killedOtherName"].Value;
                message.KilledOtherID = match.Groups["killedOtherId"].Value;
                Int32.TryParse(match.Groups["killedPosX"].Value, out int killedPosX);
                message.KilledUserPosX = killedPosX;
                Int32.TryParse(match.Groups["killedPosY"].Value, out int killedPosY);
                message.KilledUserPosY = killedPosY;
                Int32.TryParse(match.Groups["killedPosZ"].Value, out int killedPosZ);
                message.KilledUserPosZ = killedPosZ;
                message.Weapon = match.Groups["weapon"].Value;

                Regex headshotRegex = new Regex(headshotPattern);
                if (headshotRegex.IsMatch(match.Groups["headshotOrPenetrated"].Value))
                {
                    message.IsHeadshot = true;
                }
                else
                {
                    message.IsHeadshot = false;
                }

                Regex penetratedRegex = new Regex(penetratedPattern);
                if (penetratedRegex.IsMatch(match.Groups["headshotOrPenetrated"].Value))
                {
                    message.IsPenetrated = true;
                }
                else
                {
                    message.IsPenetrated = false;
                }

                return message;
            }
            return null;
        }
    }
}