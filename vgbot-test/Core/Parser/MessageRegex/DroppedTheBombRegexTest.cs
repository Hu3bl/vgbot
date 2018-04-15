using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class DroppedTheBombRegexTest
    {
        [Fact]        
        public void CheckDroppedTheBombRegex_DroppedTheBombMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" triggered \"Dropped_The_Bomb\"";
                        
            var regex = new DroppedTheBombRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var droppedTheBombMessage = (DroppedTheBombMessage) message;         
                        
            Assert.Equal("Hu3bl", droppedTheBombMessage.UserName);
            Assert.Equal("2", droppedTheBombMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", droppedTheBombMessage.UserSteamID);
            Assert.Equal("TERRORIST", droppedTheBombMessage.UserTeam);
        }
    }
}