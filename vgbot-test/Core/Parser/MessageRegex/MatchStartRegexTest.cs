using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class MatchStartRegexTest
    {
        [Fact]
        public void CheckMatchStartRegex_MatchStartMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "World triggered \"Match_Start\" on \"de_inferno\"";

            var regex = new MatchStartRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var matchStartMessage = (MatchStartMessage)message;

            Assert.Equal("de_inferno", matchStartMessage.Map);
        }
    }
}