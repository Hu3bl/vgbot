using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class KilledOtherRegexTest
    {
        [Fact]
        public void KilledOtherRegex_KilledOtherMessageAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"WeedMonkey<67><STEAM_1:1:84194999><TERRORIST>\" [341 -429 96] killed other \"chicken<194>\" [344 -451 96] with \"knife_t\"";

            var regex = new KilledOtherRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var killedOtherMessage = (KilledOtherMessage)abstractMessage;

            Assert.Equal("WeedMonkey", killedOtherMessage.UserName);
            Assert.Equal("67", killedOtherMessage.UserID);
            Assert.Equal("STEAM_1:1:84194999", killedOtherMessage.UserSteamID);
            Assert.Equal("TERRORIST", killedOtherMessage.UserTeam);
            Assert.Equal(341, killedOtherMessage.UserPosX);
            Assert.Equal(-429, killedOtherMessage.UserPosY);
            Assert.Equal(96, killedOtherMessage.UserPosZ);
            Assert.Equal("chicken", killedOtherMessage.KilledOtherName);
            Assert.Equal("194", killedOtherMessage.KilledOtherID);
            Assert.Equal(344, killedOtherMessage.KilledUserPosX);
            Assert.Equal(-451, killedOtherMessage.KilledUserPosY);
            Assert.Equal(96, killedOtherMessage.KilledUserPosZ);
            Assert.Equal("knife_t", killedOtherMessage.Weapon);
            Assert.False(killedOtherMessage.IsHeadshot);
            Assert.False(killedOtherMessage.IsPenetrated);
        }

        [Fact]
        public void CheckKilledOtherRegex_KilledOtherMessageWithHeadshotAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"WeedMonkey<67><STEAM_1:1:84194999><TERRORIST>\" [341 -429 96] killed other \"chicken<194>\" [344 -451 96] with \"knife_t\" (headshot)";

            var regex = new KilledOtherRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var killedOtherMessage = (KilledOtherMessage)abstractMessage;

            Assert.Equal("WeedMonkey", killedOtherMessage.UserName);
            Assert.Equal("67", killedOtherMessage.UserID);
            Assert.Equal("STEAM_1:1:84194999", killedOtherMessage.UserSteamID);
            Assert.Equal("TERRORIST", killedOtherMessage.UserTeam);
            Assert.Equal(341, killedOtherMessage.UserPosX);
            Assert.Equal(-429, killedOtherMessage.UserPosY);
            Assert.Equal(96, killedOtherMessage.UserPosZ);
            Assert.Equal("chicken", killedOtherMessage.KilledOtherName);
            Assert.Equal("194", killedOtherMessage.KilledOtherID);
            Assert.Equal(344, killedOtherMessage.KilledUserPosX);
            Assert.Equal(-451, killedOtherMessage.KilledUserPosY);
            Assert.Equal(96, killedOtherMessage.KilledUserPosZ);
            Assert.Equal("knife_t", killedOtherMessage.Weapon);
            Assert.True(killedOtherMessage.IsHeadshot);
            Assert.False(killedOtherMessage.IsPenetrated);
        }

        [Fact]
        public void CheckKilledOtherRegex_KilledOtherMessageWithPenetratedAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"WeedMonkey<67><STEAM_1:1:84194999><TERRORIST>\" [341 -429 96] killed other \"chicken<194>\" [344 -451 96] with \"knife_t\" (penetrated)";

            var regex = new KilledOtherRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var killedOtherMessage = (KilledOtherMessage)abstractMessage;

            Assert.Equal("WeedMonkey", killedOtherMessage.UserName);
            Assert.Equal("67", killedOtherMessage.UserID);
            Assert.Equal("STEAM_1:1:84194999", killedOtherMessage.UserSteamID);
            Assert.Equal("TERRORIST", killedOtherMessage.UserTeam);
            Assert.Equal(341, killedOtherMessage.UserPosX);
            Assert.Equal(-429, killedOtherMessage.UserPosY);
            Assert.Equal(96, killedOtherMessage.UserPosZ);
            Assert.Equal("chicken", killedOtherMessage.KilledOtherName);
            Assert.Equal("194", killedOtherMessage.KilledOtherID);
            Assert.Equal(344, killedOtherMessage.KilledUserPosX);
            Assert.Equal(-451, killedOtherMessage.KilledUserPosY);
            Assert.Equal(96, killedOtherMessage.KilledUserPosZ);
            Assert.Equal("knife_t", killedOtherMessage.Weapon);
            Assert.False(killedOtherMessage.IsHeadshot);
            Assert.True(killedOtherMessage.IsPenetrated);
        }

        [Fact]
        public void CheckKilledOtherRegex_KilledOtherMessageWithHeadshotPenetratedAsInput_ExpectedCorrectConstructionOfObject()
        {
            string input = "\"WeedMonkey<67><STEAM_1:1:84194999><TERRORIST>\" [341 -429 96] killed other \"chicken<194>\" [344 -451 96] with \"knife_t\" (headshot penetrated)";

            var regex = new KilledOtherRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var killedOtherMessage = (KilledOtherMessage)abstractMessage;

            Assert.Equal("WeedMonkey", killedOtherMessage.UserName);
            Assert.Equal("67", killedOtherMessage.UserID);
            Assert.Equal("STEAM_1:1:84194999", killedOtherMessage.UserSteamID);
            Assert.Equal("TERRORIST", killedOtherMessage.UserTeam);
            Assert.Equal(341, killedOtherMessage.UserPosX);
            Assert.Equal(-429, killedOtherMessage.UserPosY);
            Assert.Equal(96, killedOtherMessage.UserPosZ);
            Assert.Equal("chicken", killedOtherMessage.KilledOtherName);
            Assert.Equal("194", killedOtherMessage.KilledOtherID);
            Assert.Equal(344, killedOtherMessage.KilledUserPosX);
            Assert.Equal(-451, killedOtherMessage.KilledUserPosY);
            Assert.Equal(96, killedOtherMessage.KilledUserPosZ);
            Assert.Equal("knife_t", killedOtherMessage.Weapon);
            Assert.True(killedOtherMessage.IsHeadshot);
            Assert.True(killedOtherMessage.IsPenetrated);
        }
    }
}