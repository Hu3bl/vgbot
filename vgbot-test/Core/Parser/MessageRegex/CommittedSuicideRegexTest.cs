using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class CommittedSuicideRegexTest
    {
        [Fact]
        public void CheckCommittedSuicideRegex_WorldSuicideMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"richtiger TinaSohn<30><STEAM_1:1:15005833><TERRORIST>\" [-1404 -1569 -181] committed suicide with \"world\"";

            var regex = new CommittedSuicideRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var committedSuicideMessage = (CommittedSuicideMessage)message;

            Assert.Equal("richtiger TinaSohn", committedSuicideMessage.UserName);
            Assert.Equal("30", committedSuicideMessage.UserID);
            Assert.Equal("STEAM_1:1:15005833", committedSuicideMessage.UserSteamID);
            Assert.Equal("TERRORIST", committedSuicideMessage.UserTeam);
            Assert.Equal(-1404, committedSuicideMessage.PosX);
            Assert.Equal(-1569, committedSuicideMessage.PosY);
            Assert.Equal(-181, committedSuicideMessage.PosZ);
            Assert.Equal("world", committedSuicideMessage.Reason);
        }

        [Fact]
        public void CheckCommittedSuicideRegex_InfernoSuicideMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"richtiger TinaSohn<30><STEAM_1:1:15005833><TERRORIST>\" [-1404 -1569 -181] committed suicide with \"inferno\"";

            var regex = new CommittedSuicideRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var committedSuicideMessage = (CommittedSuicideMessage)message;

            Assert.Equal("richtiger TinaSohn", committedSuicideMessage.UserName);
            Assert.Equal("30", committedSuicideMessage.UserID);
            Assert.Equal("STEAM_1:1:15005833", committedSuicideMessage.UserSteamID);
            Assert.Equal("TERRORIST", committedSuicideMessage.UserTeam);
            Assert.Equal(-1404, committedSuicideMessage.PosX);
            Assert.Equal(-1569, committedSuicideMessage.PosY);
            Assert.Equal(-181, committedSuicideMessage.PosZ);
            Assert.Equal("inferno", committedSuicideMessage.Reason);
        }
    }
}