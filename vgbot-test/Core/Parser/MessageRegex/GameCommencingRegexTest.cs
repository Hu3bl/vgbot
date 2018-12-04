using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class GameCommencingRegexTest
    {
        [Fact]
        public void CheckGameCommencingRegex_GameCommencingMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "World triggered \"Game_Commencing\"";

            var regex = new GameCommencingRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            Assert.True(abstractMessage is GameCommencingMessage);
        }
    }
}