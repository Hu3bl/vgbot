using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class MolotovSpawnedRegexTest
    {
        [Fact]
        public void CheckMolotovSpawnedRegex_MolotovSpawnedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "Molotov projectile spawned at -738.042908 10.161488 224.233917, velocity -423.780396 -854.355225 8.549564";
            
            var regex = new MolotovSpawnedRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var molotovSpawnedMessage = (MolotovSpawnedMessage) message; 
                    
            Assert.Equal("-738.042908", molotovSpawnedMessage.PosX);
            Assert.Equal("10.161488", molotovSpawnedMessage.PosY);
            Assert.Equal("224.233917",molotovSpawnedMessage.PosZ);
            Assert.Equal("-423.780396", molotovSpawnedMessage.VelocityX);
            Assert.Equal("-854.355225", molotovSpawnedMessage.VelocityY);
            Assert.Equal("8.549564", molotovSpawnedMessage.VelocityZ);
        }	
    }
}