using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class SayRegexTest
    {
        [Fact]        
        public void CheckSayRegex_SayMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" say \":D\"";
		
            var regex = new SayRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var sayMessage = (SayMessage) message;         
                        
            Assert.Equal("Hu3bl", sayMessage.UserName);
            Assert.Equal("2", sayMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", sayMessage.UserSteamID);
            Assert.Equal("TERRORIST", sayMessage.UserTeam);
            Assert.Equal(":D", sayMessage.Text);
        }
    }
}