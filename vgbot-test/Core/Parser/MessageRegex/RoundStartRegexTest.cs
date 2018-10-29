using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class RoundStartRegexTest
    {
        [Fact]        
        public void CheckRoundStartRegex_RoundStartMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "World triggered \"Round_Start\"";
		
            var regex = new RoundStartRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            Assert.True(message is RoundStartMessage);
        }
    }
}