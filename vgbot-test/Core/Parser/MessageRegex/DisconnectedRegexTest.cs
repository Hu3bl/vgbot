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
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var disconnectedMessage = (DisconnectedMessage) message;

            Assert.Equal("Hu3bl", disconnectedMessage.UserName);
            Assert.Equal("2", disconnectedMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", disconnectedMessage.UserSteamID);
            Assert.Equal("CT", disconnectedMessage.UserTeam);
            Assert.Equal("Disconnect", disconnectedMessage.Reason);
        }

        [Fact]
        public void CheckDisconnectedRegex_DisconnectedMessageFromLogAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"WeedMonkey<77><STEAM_1:1:84194999><>\" disconnected (reason \"Disconnect\")";
            
            var regex = new DisconnectedRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var disconnectedMessage = (DisconnectedMessage) message;

            Assert.Equal("WeedMonkey", disconnectedMessage.UserName);
            Assert.Equal("77", disconnectedMessage.UserID);
            Assert.Equal("STEAM_1:1:84194999", disconnectedMessage.UserSteamID);
            Assert.Equal("", disconnectedMessage.UserTeam);
            Assert.Equal("Disconnect", disconnectedMessage.Reason);
        }
    }
}