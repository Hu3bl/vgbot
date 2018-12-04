using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class StartingFreezePeriodRegexTest
    {
        [Fact]
        public void CheckStartingFreezePeriodRegex_StartingFreezePeriodMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            String input = "Starting Freeze period";

            var regex = new StartingFreezePeriodRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            Assert.True(abstractMessage is StartingFreezePeriodMessage);
        }
    }
}