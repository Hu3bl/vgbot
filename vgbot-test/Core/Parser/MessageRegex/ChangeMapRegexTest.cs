using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class ChangeMapRegexTest
    {
        [Fact]        
        public void CheckChangeMapRegex_ChangeMapMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "Loading map \"de_cbble\"";
            
            var regex = new ChangeMapRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var changeMapMessage = (ChangeMapMessage) message;         
                        
            Assert.Equal("Loading map", changeMapMessage.Type);
            Assert.Equal("de_cbble", changeMapMessage.Map);
        }
    }
}