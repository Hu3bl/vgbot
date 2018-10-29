using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class KilledByTheBombRegexTest
    {
        [Fact]
        public void CheckKilledByTheBombRegex_KilledByBombMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"specialgreg<63><STEAM_1:0:127388238><TERRORIST>\" [726 -947 1678] was killed by the bomb.";

            var regex = new KilledByTheBombRegex();
            IMessage message = regex.Parse(input);
            Assert.NotNull(message);
            var killedByTheBombMessage = (KilledByTheBombMessage)message;

            Assert.Equal("specialgreg", killedByTheBombMessage.UserName);
            Assert.Equal("63", killedByTheBombMessage.UserID);
            Assert.Equal("STEAM_1:0:127388238", killedByTheBombMessage.UserSteamID);
            Assert.Equal("TERRORIST", killedByTheBombMessage.UserTeam);
            Assert.Equal(726, killedByTheBombMessage.PosX);
            Assert.Equal(-947, killedByTheBombMessage.PosY);
            Assert.Equal(1678, killedByTheBombMessage.PosZ);
        }
    }
}