using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class RoundRestartRegexTest
    {
        [Fact]        
        public void CheckRoundRestartRegex_RoundRestartMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "World triggered \"Restart_Round_(3_seconds)\"";
		
            var regex = new RoundRestartRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var roundRestartMessage = (RoundRestartMessage) message;          
                        
            Assert.Equal(3, roundRestartMessage.Seconds);
        }
    }
}