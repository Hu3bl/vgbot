using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class ConnectedRegexTest
    {
        [Fact]        
        public void CheckConnectedRegex_ConnectedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><>\" connected, address \"\"";
                        
            var regex = new ConnectedRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var connectedMessage = (ConnectedMessage) message;         
                        
            Assert.Equal("Hu3bl", connectedMessage.UserName);
            Assert.Equal("2", connectedMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", connectedMessage.UserSteamID);
            Assert.Equal("", connectedMessage.Address);
        }
    }
}