﻿using System;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class KilledByTheBombRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\""
                                                 + " \\[(?<posX>[\\-]?[0-9]+) (?<posY>[\\-]?[0-9]+) (?<posZ>[\\-]?[0-9]+)\\] was killed by the bomb.";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                var message = new KilledByTheBombMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                Int32.TryParse(match.Groups["posX"].Value, out int posX);
                message.PosX = posX;
                Int32.TryParse(match.Groups["posY"].Value, out int posY);
                message.PosY = posY;
                Int32.TryParse(match.Groups["posZ"].Value, out int posZ);
                message.PosZ = posZ;

                return message;
            }
            return null;
        }
    }
}