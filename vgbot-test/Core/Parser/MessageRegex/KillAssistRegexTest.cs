using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class KillAssistRegexTest
    {
        [Fact]        
        public void CheckKillAssistRegex_KillAssistMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" assisted killing \"Yahn<3><BOT><CT>\"";
		
            var regex = new KillAssistRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var killAssistMessage = (KillAssistMessage) message;         
                        
            Assert.Equal("Hu3bl", killAssistMessage.UserName);
            Assert.Equal("2", killAssistMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", killAssistMessage.UserSteamID);
            Assert.Equal("TERRORIST", killAssistMessage.UserTeam);
            Assert.Equal("Yahn", killAssistMessage.KilledUserName);
            Assert.Equal("3", killAssistMessage.KilledUserID);
            Assert.Equal("BOT", killAssistMessage.KilledUserSteamID);
            Assert.Equal("CT", killAssistMessage.KilledUserTeam);
        }
    }
}