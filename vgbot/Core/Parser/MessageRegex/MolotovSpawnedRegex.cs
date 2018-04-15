using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class MolotovSpawnedRegex : IRegex
    {
        private static readonly string pattern = "Molotov projectile spawned at (?<posX>.+) (?<posY>.+) (?<posZ>.+), velocity (?<velocityX>.+) (?<velocityY>.+) (?<velocityZ>.+)";
       
        public bool TryParse(string input, out IMessage outMessage)
        {
            outMessage = null;
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(input);
            if(isMatch)
            {
                MolotovSpawnedMessage message = new MolotovSpawnedMessage();
                var match = regex.Match(input);
                message.PosX = match.Groups["posX"].Value;
                message.PosY = match.Groups["posY"].Value;
                message.PosZ = match.Groups["posZ"].Value;
                message.VelocityX = match.Groups["velocityX"].Value;
                message.VelocityY = match.Groups["velocityY"].Value;
                message.VelocityZ = match.Groups["velocityZ"].Value;               
                                                                     
                outMessage = message;
            }
            return isMatch;
        }
    }
}