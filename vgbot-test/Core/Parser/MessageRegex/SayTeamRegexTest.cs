using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class SayTeamRegexTest
    {
        [Fact]        
        public void CheckSayTeamRegex_SayTeamMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" say_team \":D\"";
		
            var regex = new SayTeamRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var sayTeamMessage = (SayTeamMessage) message;         
                        
            Assert.Equal("Hu3bl", sayTeamMessage.UserName);
            Assert.Equal("2", sayTeamMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", sayTeamMessage.UserSteamID);
            Assert.Equal("TERRORIST", sayTeamMessage.UserTeam);
            Assert.Equal(":D", sayTeamMessage.Text);
        }
    }
}