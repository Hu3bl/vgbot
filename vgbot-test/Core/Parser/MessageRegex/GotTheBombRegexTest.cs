using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class GotTheBombRegexTest
    {
        [Fact]        
        public void CheckGotTheBombRegexRegex_GotTheBombMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" triggered \"Got_The_Bomb\"";
                        
            var regex = new GotTheBombRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var gotTheBombMessage = (GotTheBombMessage) message;         
                        
            Assert.Equal("Hu3bl", gotTheBombMessage.UserName);
            Assert.Equal("2", gotTheBombMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", gotTheBombMessage.UserSteamID);
            Assert.Equal("TERRORIST", gotTheBombMessage.UserTeam);
        }
    }
}