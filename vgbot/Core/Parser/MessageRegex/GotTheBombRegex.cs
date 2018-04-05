using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class GotTheBombRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" triggered \"Got_The_Bomb\"";

        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                GotTheBombMessage message = new GotTheBombMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups[1].Value;
                message.UserID = match.Groups[2].Value;
                message.UserSteamID = match.Groups[3].Value;
                message.UserTeam = match.Groups[4].Value;
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}