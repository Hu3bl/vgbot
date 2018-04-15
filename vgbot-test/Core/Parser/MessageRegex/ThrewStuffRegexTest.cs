using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class ThrewStuffRegexTest
    {
        [Fact]        
        public void CheckThrewStuffRegex_MolotovThrewStuffMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" threw molotov [389 -65 -3]";
		
            var regex = new ThrewStuffRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var threwStuffMessage = (ThrewStuffMessage) message;         
                        
            Assert.Equal("Hu3bl", threwStuffMessage.UserName);
            Assert.Equal("2", threwStuffMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", threwStuffMessage.UserSteamID);
            Assert.Equal("TERRORIST", threwStuffMessage.UserTeam);
            Assert.Equal("molotov", threwStuffMessage.Stuff);
            Assert.Equal(389, threwStuffMessage.PosX);
            Assert.Equal(-65, threwStuffMessage.PosY);
            Assert.Equal(-3, threwStuffMessage.PosZ);
            Assert.Equal(0, threwStuffMessage.Entindex);
        }

        [Fact]        
        public void CheckThrewStuffRegex_FlashbangThrewStuffMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" threw flashbang [389 -65 -3] flashbang entindex 196)";
		
            var regex = new ThrewStuffRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var threwStuffMessage = (ThrewStuffMessage) message;         
                        
            Assert.Equal("Hu3bl", threwStuffMessage.UserName);
            Assert.Equal("2", threwStuffMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", threwStuffMessage.UserSteamID);
            Assert.Equal("TERRORIST", threwStuffMessage.UserTeam);
            Assert.Equal("flashbang", threwStuffMessage.Stuff);
            Assert.Equal(389, threwStuffMessage.PosX);
            Assert.Equal(-65, threwStuffMessage.PosY);
            Assert.Equal(-3, threwStuffMessage.PosZ);
            Assert.Equal(196, threwStuffMessage.Entindex);
        }
    }
}