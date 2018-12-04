using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class TeamPlaySideRegexTest
    {
        [Fact]
        public void CheckTeamPlaySideRegex_TeamPlaySideRegexAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "Team playing \"TERRORIST\": Team AntiBumBina";

            var regex = new TeamPlaySideRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var switchTeamMessage = (TeamPlaySideMessage)abstractMessage;

            Assert.Equal("TERRORIST", switchTeamMessage.Side);
            Assert.Equal("Team AntiBumBina", switchTeamMessage.TeamName);
        }
    }
}