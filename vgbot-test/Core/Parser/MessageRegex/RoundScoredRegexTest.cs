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
            Assert.True(regex.TryParse(input, out IMessage message));
            var roundScoredMessage = (RoundScoredMessage) message;         
                        
            Assert.Equal("CT", roundScoredMessage.Team);
            Assert.Equal("CTs_Win", roundScoredMessage.Type);
            Assert.Equal(1, roundScoredMessage.ScoreCT);
            Assert.Equal(2, roundScoredMessage.ScoreT);
        }
    }
}