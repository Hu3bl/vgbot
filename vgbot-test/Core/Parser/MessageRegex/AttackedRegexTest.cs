using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class AttackedRegexTest
    {
        [Fact(Skip="Ignore until implemented.")]
        public void CheckAttackedRegex_AttackedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" [88 2512 -127] attacked \"Nate<10><BOT><CT>\" [382 2102 -126] with \"ak47\" (damage \"109\") (damage_armor \"15\") (health \"0\") (armor \"84\") (hitgroup \"head\")";
            
            AttackedMessage message = (AttackedMessage) new AttackedRegex().TryParse(input);
            
            Assert.Equal("Hu3bl", message.AttackerName);
            Assert.Equal("2", message.AttackerUserID);
            Assert.Equal("STEAM_1:1:10481859", message.AttackerSteamID);
            Assert.Equal("TERRORIST", message.AttackerTeam);
            Assert.Equal(88, message.AttackerPosX);
            Assert.Equal(2512, message.AttackerPosY);
            Assert.Equal(-127, message.AttackerPosZ);
            Assert.Equal("Nate", message.VictimName);
            Assert.Equal("10", message.VictimUserID);
            Assert.Equal("BOT", message.VictimSteamID);
            Assert.Equal("CT", message.VictimTeam);
            Assert.Equal(382, message.VictimPosX);
            Assert.Equal(2102, message.VictimPosY);
            Assert.Equal(-126, message.VictimPosZ);
            Assert.Equal("ak47", message.AttackerWeapon);
            Assert.Equal(109, message.AttackerDamage);
            Assert.Equal(15, message.AttackerDamageArmor);
            Assert.Equal(0, message.VictimHealth);
            Assert.Equal(84, message.VictimArmor);
            Assert.Equal("head", message.AttackerHitGroup);
        }	
    }
}