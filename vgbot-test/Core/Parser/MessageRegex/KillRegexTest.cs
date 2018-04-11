using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class KillRegexTest
    {
        [Fact]        
        public void CheckKillRegex_KillMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" [-608 2439 -210] killed \"Invict0<6><STEAM_1:0:1234567><CT>\" [-722 2424 -125] with \"glock\"";
            		
            var regex = new KillRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var killMessage = (KillMessage) message;         
                        
            Assert.Equal("Hu3bl", killMessage.UserName);
            Assert.Equal("2", killMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", killMessage.UserSteamID);
            Assert.Equal("TERRORIST", killMessage.UserTeam);
            Assert.Equal(-608, killMessage.UserPosX);
            Assert.Equal(2439, killMessage.UserPosY);
            Assert.Equal(-210, killMessage.UserPosZ);
            Assert.Equal("Invict0", killMessage.KilledUserName);
            Assert.Equal("6", killMessage.KilledUserID);
            Assert.Equal("STEAM_1:0:1234567", killMessage.KilledUserSteamID);
            Assert.Equal("CT", killMessage.KilledUserTeam);
            Assert.Equal(-722, killMessage.KilledUserPosX);
            Assert.Equal(2424, killMessage.KilledUserPosY);
            Assert.Equal(-125, killMessage.KilledUserPosZ);
            Assert.Equal("glock", killMessage.Weapon);
            Assert.False(killMessage.IsHeadshot);
            Assert.False(killMessage.IsPenetrated);
        }

        [Fact]        
        public void CheckKillRegex_KillMessageWithHeadshotAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" [-608 2439 -210] killed \"Invict0<6><STEAM_1:0:1234567><CT>\" [-722 2424 -125] with \"glock\" (headshot)";
            		
            var regex = new KillRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var killMessage = (KillMessage) message;         
                        
            Assert.Equal("Hu3bl", killMessage.UserName);
            Assert.Equal("2", killMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", killMessage.UserSteamID);
            Assert.Equal("TERRORIST", killMessage.UserTeam);
            Assert.Equal(-608, killMessage.UserPosX);
            Assert.Equal(2439, killMessage.UserPosY);
            Assert.Equal(-210, killMessage.UserPosZ);
            Assert.Equal("Invict0", killMessage.KilledUserName);
            Assert.Equal("6", killMessage.KilledUserID);
            Assert.Equal("STEAM_1:0:1234567", killMessage.KilledUserSteamID);
            Assert.Equal("CT", killMessage.KilledUserTeam);
            Assert.Equal(-722, killMessage.KilledUserPosX);
            Assert.Equal(2424, killMessage.KilledUserPosY);
            Assert.Equal(-125, killMessage.KilledUserPosZ);
            Assert.Equal("glock", killMessage.Weapon);
            Assert.True(killMessage.IsHeadshot);
            Assert.False(killMessage.IsPenetrated);
        }

        [Fact]        
        public void CheckKillRegex_KillMessageWithPenetratedAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" [-608 2439 -210] killed \"Invict0<6><STEAM_1:0:1234567><CT>\" [-722 2424 -125] with \"glock\" (penetrated)";
            		
            var regex = new KillRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var killMessage = (KillMessage) message;         
                        
            Assert.Equal("Hu3bl", killMessage.UserName);
            Assert.Equal("2", killMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", killMessage.UserSteamID);
            Assert.Equal("TERRORIST", killMessage.UserTeam);
            Assert.Equal(-608, killMessage.UserPosX);
            Assert.Equal(2439, killMessage.UserPosY);
            Assert.Equal(-210, killMessage.UserPosZ);
            Assert.Equal("Invict0", killMessage.KilledUserName);
            Assert.Equal("6", killMessage.KilledUserID);
            Assert.Equal("STEAM_1:0:1234567", killMessage.KilledUserSteamID);
            Assert.Equal("CT", killMessage.KilledUserTeam);
            Assert.Equal(-722, killMessage.KilledUserPosX);
            Assert.Equal(2424, killMessage.KilledUserPosY);
            Assert.Equal(-125, killMessage.KilledUserPosZ);
            Assert.Equal("glock", killMessage.Weapon);
            Assert.False(killMessage.IsHeadshot);
            Assert.True(killMessage.IsPenetrated);
        }

        [Fact]        
        public void CheckKillRegex_KillMessageWithHeadshotPenetratedAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" [-608 2439 -210] killed \"Invict0<6><STEAM_1:0:1234567><CT>\" [-722 2424 -125] with \"glock\" (headshot penetrated)";
            		
            var regex = new KillRegex();
            Assert.True(regex.TryParse(input, out IMessage message));
            var killMessage = (KillMessage) message;         
                        
            Assert.Equal("Hu3bl", killMessage.UserName);
            Assert.Equal("2", killMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", killMessage.UserSteamID);
            Assert.Equal("TERRORIST", killMessage.UserTeam);
            Assert.Equal(-608, killMessage.UserPosX);
            Assert.Equal(2439, killMessage.UserPosY);
            Assert.Equal(-210, killMessage.UserPosZ);
            Assert.Equal("Invict0", killMessage.KilledUserName);
            Assert.Equal("6", killMessage.KilledUserID);
            Assert.Equal("STEAM_1:0:1234567", killMessage.KilledUserSteamID);
            Assert.Equal("CT", killMessage.KilledUserTeam);
            Assert.Equal(-722, killMessage.KilledUserPosX);
            Assert.Equal(2424, killMessage.KilledUserPosY);
            Assert.Equal(-125, killMessage.KilledUserPosZ);
            Assert.Equal("glock", killMessage.Weapon);
            Assert.True(killMessage.IsHeadshot);
            Assert.True(killMessage.IsPenetrated);
        }
    }
}