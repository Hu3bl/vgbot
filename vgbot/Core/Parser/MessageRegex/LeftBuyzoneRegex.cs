using System.Collections.Generic;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class LeftBuyzoneRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" left buyzone with \\[ (?<objects>.*)\\]";

        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                LeftBuyzoneMessage abstractMessage = new LeftBuyzoneMessage();
                var match = regex.Match(input);
                abstractMessage.UserName = match.Groups["userName"].Value;
                abstractMessage.UserID = match.Groups["userId"].Value;
                abstractMessage.UserSteamID = match.Groups["userSteamId"].Value;
                abstractMessage.UserTeam = match.Groups["userTeam"].Value;
                abstractMessage.Objects = new List<string>();
                var objects = match.Groups["objects"].Value;
                if(objects != string.Empty)
                {
                    foreach (var item in objects.Split(" "))
                    {
                        if(item != string.Empty)
                        {
                            abstractMessage.Objects.Add(item);
                        }                        
                    }                    
                }
                                                                                    
                return abstractMessage;
            }
            return null;
        }
    }
}