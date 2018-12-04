using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class RoundScoredRegexTest
    {
        [Fact]        
        public void CheckRoundScoredRegex_RoundScoredMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "Team \"CT\" triggered \"SFUI_Notice_CTs_Win\" (CT \"1\") (T \"2\")";
		
            var regex = new RoundScoredRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var roundScoredMessage = (RoundScoredMessage) abstractMessage;         
                        
            Assert.Equal("CT", roundScoredMessage.Team);
            Assert.Equal("CTs_Win", roundScoredMessage.Type);
            Assert.Equal(1, roundScoredMessage.ScoreCT);
            Assert.Equal(2, roundScoredMessage.ScoreT);
        }
    }
}