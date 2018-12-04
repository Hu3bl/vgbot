using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class SwitchTeamRegexTest
    {
        [Fact]        
        public void CheckSwitchTeamRegex_SwitchTeamMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859>\" switched from team <TERRORIST> to <CT>";
		
            var regex = new SwitchTeamRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var switchTeamMessage = (SwitchTeamMessage) abstractMessage;         
                        
            Assert.Equal("Hu3bl", switchTeamMessage.UserName);
            Assert.Equal("2", switchTeamMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", switchTeamMessage.UserSteamID);
            Assert.Equal("TERRORIST", switchTeamMessage.UserTeam);
            Assert.Equal("CT", switchTeamMessage.SwitchedTeam);
        }
    }
}