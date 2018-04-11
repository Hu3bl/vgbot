using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class EnteredTheGameRegexTest
    {
        [Fact]        
        public void CheckEnteredTheGameRegex_EnteredTheGameMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><>\" entered the game";
                        
            var regex = new EnteredTheGameRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var enteredTheGameMessage = (EnteredTheGameMessage) message;         
                        
            Assert.Equal("Hu3bl", enteredTheGameMessage.UserName);
            Assert.Equal("2", enteredTheGameMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", enteredTheGameMessage.UserSteamID);
        }
    }
}