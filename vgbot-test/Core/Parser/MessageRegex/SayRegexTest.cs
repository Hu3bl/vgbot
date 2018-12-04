using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class SayRegexTest
    {
        [Fact]        
        public void CheckSayRegex_SayMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" say \":D\"";
		
            var regex = new SayRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var sayMessage = (SayMessage) abstractMessage;         
                        
            Assert.Equal("Hu3bl", sayMessage.UserName);
            Assert.Equal("2", sayMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", sayMessage.UserSteamID);
            Assert.Equal("TERRORIST", sayMessage.UserTeam);
            Assert.Equal(":D", sayMessage.Text);
        }

        [Fact]
        public void CheckSayRegex_SayMessageFromConsoleAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"Console<0><Console><Console>\" say \"\"> ESL CS:GO 3on3/5on5 Ladder Config loaded - 14.01.2016<\"\"";

            var regex = new SayRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var sayMessage = (SayMessage)abstractMessage;

            Assert.Equal("Console", sayMessage.UserName);
            Assert.Equal("0", sayMessage.UserID);
            Assert.Equal("Console", sayMessage.UserSteamID);
            Assert.Equal("Console", sayMessage.UserTeam);
            Assert.Equal("\"> ESL CS:GO 3on3/5on5 Ladder Config loaded - 14.01.2016<\"", sayMessage.Text);
        }
    }
}