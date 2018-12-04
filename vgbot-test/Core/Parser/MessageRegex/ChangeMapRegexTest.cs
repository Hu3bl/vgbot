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
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var changeMapMessage = (ChangeMapMessage) abstractMessage;         
                        
            Assert.Equal("Loading map", changeMapMessage.Type);
            Assert.Equal("de_cbble", changeMapMessage.Map);
        }
    }
}