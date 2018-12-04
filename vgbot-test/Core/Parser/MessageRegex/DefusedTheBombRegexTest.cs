using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class DefusedTheBombRegexTest
    {
        [Fact]
        public void CheckDefusedTheBombRegex_DroppedTheBombMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"richtiger TinaSohn<30><STEAM_1:1:15005833><CT>\" triggered \"Defused_The_Bomb\"";

            var regex = new DefusedTheBombRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var defusedTheBombMessage = (DefusedTheBombMessage)abstractMessage;

            Assert.Equal("richtiger TinaSohn", defusedTheBombMessage.UserName);
            Assert.Equal("30", defusedTheBombMessage.UserID);
            Assert.Equal("STEAM_1:1:15005833", defusedTheBombMessage.UserSteamID);
            Assert.Equal("CT", defusedTheBombMessage.UserTeam);
        }
    }
}