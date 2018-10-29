using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class DefusedTheBombRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" triggered \"Defused_The_Bomb\"";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                DefusedTheBombMessage message = new DefusedTheBombMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;

                return message;
            }
            return null;
        }
    }
}