using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class ChangeNameRegexTest
    {
        [Fact]        
        public void CheckChangeNameRegex_ChangeNameMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><CT>\" changed name to \"Hu3blele\"";
            
            var regex = new ChangeNameRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var changeNameMessage = (ChangeNameMessage) message;         
                        
            Assert.Equal("Hu3bl", changeNameMessage.UserName);
            Assert.Equal("2", changeNameMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", changeNameMessage.UserSteamID);
            Assert.Equal("CT", changeNameMessage.UserTeam);
            Assert.Equal("Hu3blele", changeNameMessage.NewUserName);
        }
    }
}