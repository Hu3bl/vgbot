using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class RoundEndRegexTest
    {
        [Fact]        
        public void CheckRoundEndRegex_RoundEndMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "World triggered \"Round_End\"";
		
            var regex = new RoundEndRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            Assert.True(message is RoundEndMessage);
        }
    }
}