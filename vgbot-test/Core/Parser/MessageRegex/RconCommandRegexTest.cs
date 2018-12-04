using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class RconCommandRegexTest
    {
        [Fact]        
        public void CheckRconCommandRegex_RconCommandMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "rcon from \"172.17.0.3:37058\": command \"exec server.cfg;\"";
		
            var regex = new RconCommandRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var rconCommandMessage = (RconCommandMessage) abstractMessage;         
                        
            Assert.Equal("172.17.0.3:37058", rconCommandMessage.From);
            Assert.Equal("exec server.cfg;", rconCommandMessage.Command);
        }
    }
}