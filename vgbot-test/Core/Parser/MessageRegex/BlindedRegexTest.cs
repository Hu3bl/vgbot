using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class BlindedRegexTest
    {
        [Fact]
        public void CheckBlindedRegex_BlindedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Nate<10><BOT><CT>\" blinded for 4.31 by \"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" from flashbang entindex 343";
            
            var regex = new BlindedRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var blindedMessage = (BlindedMessage) message; 
                    
            Assert.Equal("Hu3bl", blindedMessage.UserName);
            Assert.Equal("2", blindedMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859",blindedMessage.UserSteamID);
            Assert.Equal("TERRORIST", blindedMessage.UserTeam);
            Assert.Equal("Nate", blindedMessage.VictimUserName);
            Assert.Equal("10", blindedMessage.VictimUserID);
            Assert.Equal("BOT", blindedMessage.VictimUserSteamID);
            Assert.Equal("CT", blindedMessage.VictimUserTeam);
            Assert.Equal(4.31, blindedMessage.Duration);
            Assert.Equal(343, blindedMessage.Entindex);
        }	
    }
}