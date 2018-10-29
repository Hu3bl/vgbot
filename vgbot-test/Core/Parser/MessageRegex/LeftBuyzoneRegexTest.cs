using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class LeftBuyzoneRegexTest
    {
        [Fact]        
        public void CheckLeftBuyzoneRegex_LeftBuyzoneMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" left buyzone with [ weapon_knife_karambit weapon_p250 weapon_awp kevlar(74) helmet ]";
		
            var regex = new LeftBuyzoneRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var leftBuyzoneMessage = (LeftBuyzoneMessage) message;         
                        
            Assert.Equal("Hu3bl", leftBuyzoneMessage.UserName);
            Assert.Equal("2", leftBuyzoneMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", leftBuyzoneMessage.UserSteamID);
            Assert.Equal("TERRORIST", leftBuyzoneMessage.UserTeam);
            Assert.Equal(5, leftBuyzoneMessage.Objects.Count);
            Assert.Equal("weapon_knife_karambit", leftBuyzoneMessage.Objects[0]);
            Assert.Equal("weapon_p250", leftBuyzoneMessage.Objects[1]);
            Assert.Equal("weapon_awp", leftBuyzoneMessage.Objects[2]);
            Assert.Equal("kevlar(74)", leftBuyzoneMessage.Objects[3]);
            Assert.Equal("helmet", leftBuyzoneMessage.Objects[4]);
        }

        [Fact]        
        public void CheckLeftBuyzoneRegex_EmptyLeftBuyzoneMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" left buyzone with [ ]";
		
            var regex = new LeftBuyzoneRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var leftBuyzoneMessage = (LeftBuyzoneMessage) message;         
                        
            Assert.Equal("Hu3bl", leftBuyzoneMessage.UserName);
            Assert.Equal("2", leftBuyzoneMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", leftBuyzoneMessage.UserSteamID);
            Assert.Equal("TERRORIST", leftBuyzoneMessage.UserTeam);
            Assert.Equal(0, leftBuyzoneMessage.Objects.Count);
        }
    }
}