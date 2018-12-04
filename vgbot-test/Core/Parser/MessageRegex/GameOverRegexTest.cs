using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class GameOverRegexTest
    {
        [Fact]
        public void CheckGameOverRegex_GameOverMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            String input = "Game Over: competitive  de_cache score 16:8 after 35 min";

            var regex = new GameOverRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var gameOverMessage = (GameOverMessage)abstractMessage;

            Assert.Equal("competitive", gameOverMessage.GameMode);
            Assert.Equal("de_cache", gameOverMessage.Map);
            Assert.Equal("16:8", gameOverMessage.Score);
            Assert.Equal(35, gameOverMessage.Duration);
        }
    }
}