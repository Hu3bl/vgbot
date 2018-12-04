using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class BombDefusingRegexTest
    {
        [Fact]        
        public void CheckBombDefusingRegex_BombDefusingMessageWithKitAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><CT>\" triggered \"Begin_Bomb_Defuse_With_Kit\"";
            
            var regex = new BombDefusingRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var bombDefusingMessage = (BombDefusingMessage) abstractMessage;         
                        
            Assert.Equal("Hu3bl", bombDefusingMessage.UserName);
            Assert.Equal("2", bombDefusingMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", bombDefusingMessage.UserSteamID);
            Assert.Equal("CT", bombDefusingMessage.UserTeam);
            Assert.Equal("Begin_Bomb_Defuse_With_Kit", bombDefusingMessage.Type);
        }

        [Fact]        
        public void CheckBombDefusingRegex_BombDefusingMessageWithoutKitAsInput_ExpectedCorrectConstructionOfObject() 
        {
            string input = "\"Hu3bl<2><STEAM_1:1:10481859><CT>\" triggered \"Begin_Bomb_Defuse_Without_Kit\"";
            
            var regex = new BombDefusingRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var bombDefusingMessage = (BombDefusingMessage) abstractMessage;         
                        
            Assert.Equal("Hu3bl", bombDefusingMessage.UserName);
            Assert.Equal("2", bombDefusingMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", bombDefusingMessage.UserSteamID);
            Assert.Equal("CT", bombDefusingMessage.UserTeam);
            Assert.Equal("Begin_Bomb_Defuse_Without_Kit", bombDefusingMessage.Type);
        }
    }
}