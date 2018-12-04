using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Vgbot.Core.Messages;

namespace Vgbot.Core.Parser.MessageRegex
{
    public class MolotovSpawnedRegex : IRegex
    {
        private static readonly string pattern = "Molotov projectile spawned at (?<posX>.+) (?<posY>.+) (?<posZ>.+), velocity (?<velocityX>.+) (?<velocityY>.+) (?<velocityZ>.+)";
       
        public AbstractMessage Parse(string input)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(input))
            {
                MolotovSpawnedMessage abstractMessage = new MolotovSpawnedMessage();
                var match = regex.Match(input);
                abstractMessage.PosX = match.Groups["posX"].Value;
                abstractMessage.PosY = match.Groups["posY"].Value;
                abstractMessage.PosZ = match.Groups["posZ"].Value;
                abstractMessage.VelocityX = match.Groups["velocityX"].Value;
                abstractMessage.VelocityY = match.Groups["velocityY"].Value;
                abstractMessage.VelocityZ = match.Groups["velocityZ"].Value;               
                                                                     
                return abstractMessage;
            }
            return null;
        }
    }
}