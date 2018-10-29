using System.Collections.Generic;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class LeftBuyzoneRegex : IRegex
    {
        private static readonly string pattern = "\"(?<userName>.+)[<](?<userId>\\d+)[>][<](?<userSteamId>.*)[>][<](?<userTeam>CT|TERRORIST|Unassigned|Spectator)[>]\" left buyzone with \\[ (?<objects>.*)\\]";

        public IMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                LeftBuyzoneMessage message = new LeftBuyzoneMessage();
                var match = regex.Match(input);
                message.UserName = match.Groups["userName"].Value;
                message.UserID = match.Groups["userId"].Value;
                message.UserSteamID = match.Groups["userSteamId"].Value;
                message.UserTeam = match.Groups["userTeam"].Value;
                message.Objects = new List<string>();
                var objects = match.Groups["objects"].Value;
                if(objects != string.Empty)
                {
                    foreach (var item in objects.Split(" "))
                    {
                        if(item != string.Empty)
                        {
                            message.Objects.Add(item);
                        }                        
                    }                    
                }
                                                                                    
                return message;
            }
            return null;
        }
    }
}