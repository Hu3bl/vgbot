using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class DisconnectedRegexTest
    {
        [Fact]        
        public void CheckDisconnectedRegex_DisconnectedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><CT>\" disconnected (reason \"Disconnect\")";
                        
            var regex = new DisconnectedRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var disconnectedMessage = (DisconnectedMessage) message;         
                        
            Assert.Equal("Hu3bl", disconnectedMessage.UserName);
            Assert.Equal("2", disconnectedMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", disconnectedMessage.UserSteamID);
            Assert.Equal("CT", disconnectedMessage.UserTeam);
            Assert.Equal("Disconnect", disconnectedMessage.Reason);
        }
    }
}