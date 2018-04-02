using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class BombPlantingRegexTest
    {
        [Fact]        
        public void CheckBombPlantingRegex_BombPlantingMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><CT>\" triggered \"Planted_The_Bomb\"";
            
            var regex = new BombPlantingRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var bombPlantingMessage = (BombPlantingMessage) message;         
                        
            Assert.Equal("Hu3bl", bombPlantingMessage.UserName);
            Assert.Equal("2", bombPlantingMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", bombPlantingMessage.UserSteamID);
            Assert.Equal("CT", bombPlantingMessage.UserTeam);
        }
    }
}