using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class TeamScoredRegexTest
    {
        [Fact]        
        public void CheckTeamScoredRegex_TeamScoredMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "Team \"CT\" scored \"7\" with \"5\" players";
		
            var regex = new TeamScoredRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var teamScoredMessage = (TeamScoredMessage) message;         
                        
            Assert.Equal("CT", teamScoredMessage.Team);
            Assert.Equal("7", teamScoredMessage.Score);
            Assert.Equal("5", teamScoredMessage.Players);
        }
    }
}