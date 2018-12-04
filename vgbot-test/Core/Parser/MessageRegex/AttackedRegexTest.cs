using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class AttackedRegexTest
    {
        [Fact]
        public void CheckAttackedRegex_AttackedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" [88 2512 -127] attacked \"Nate<10><BOT><CT>\" [382 2102 -126] with \"ak47\" (damage \"109\") (damage_armor \"15\") (health \"0\") (armor \"84\") (hitgroup \"head\")";
            
            var regex = new AttackedRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var attackedMessage = (AttackedMessage) abstractMessage; 
                    
            Assert.Equal("Hu3bl", attackedMessage.AttackerName);
            Assert.Equal("2", attackedMessage.AttackerUserID);
            Assert.Equal("STEAM_1:1:10481859",attackedMessage.AttackerSteamID);
            Assert.Equal("TERRORIST", attackedMessage.AttackerTeam);
            Assert.Equal(88, attackedMessage.AttackerPosX);
            Assert.Equal(2512, attackedMessage.AttackerPosY);
            Assert.Equal(-127, attackedMessage.AttackerPosZ);
            Assert.Equal("Nate", attackedMessage.VictimName);
            Assert.Equal("10", attackedMessage.VictimUserID);
            Assert.Equal("BOT", attackedMessage.VictimSteamID);
            Assert.Equal("CT", attackedMessage.VictimTeam);
            Assert.Equal(382, attackedMessage.VictimPosX);
            Assert.Equal(2102, attackedMessage.VictimPosY);
            Assert.Equal(-126, attackedMessage.VictimPosZ);
            Assert.Equal("ak47", attackedMessage.AttackerWeapon);
            Assert.Equal(109, attackedMessage.AttackerDamage);
            Assert.Equal(15, attackedMessage.AttackerDamageArmor);
            Assert.Equal(0, attackedMessage.VictimHealth);
            Assert.Equal(84, attackedMessage.VictimArmor);
            Assert.Equal("head", attackedMessage.AttackerHitGroup);
        }	
    }
}