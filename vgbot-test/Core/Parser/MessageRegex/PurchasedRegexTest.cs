using System;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;
using Xunit;

namespace Vgbot_test.Core.Parser.MessageRegex
{
    public class PurchasedRegexTest
    {
        [Fact]        
        public void CheckPurchasedRegex_PurchasedMessageAsInput_ExpectedCorrectConstructionOfObject() 
        {
            String input = "\"Hu3bl<2><STEAM_1:1:10481859><TERRORIST>\" purchased \"ak47\"";
		
            var regex = new PurchasedRegex();
            AbstractMessage abstractMessage = regex.Parse(input);
            Assert.NotNull(abstractMessage);
            var purchasedMessage = (PurchasedMessage) abstractMessage;         
                        
            Assert.Equal("Hu3bl", purchasedMessage.UserName);
            Assert.Equal("2", purchasedMessage.UserID);
            Assert.Equal("STEAM_1:1:10481859", purchasedMessage.UserSteamID);
            Assert.Equal("TERRORIST", purchasedMessage.UserTeam);
            Assert.Equal("ak47", purchasedMessage.PurchasedObject);
        }
    }
}