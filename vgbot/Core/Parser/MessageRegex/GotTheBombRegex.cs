using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class GotTheBombRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" triggered \"Got_The_Bomb\"";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                GotTheBombMessage abstractMessage = new GotTheBombMessage();
                var match = regex.Match(input);
                abstractMessage.UserName = match.Groups["userName"].Value;
                abstractMessage.UserID = match.Groups["userId"].Value;
                abstractMessage.UserSteamID = match.Groups["userSteamId"].Value;
                abstractMessage.UserTeam = match.Groups["userTeam"].Value;
                                                                     
                return abstractMessage;
            }
            return null;
        }
    }
}