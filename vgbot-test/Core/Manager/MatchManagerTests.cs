using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using vgbot.Core.Listener;
using Vgbot.Core.Messages;
using Xunit;

namespace Vgbot_test.Core.Manager
{
    public class MatchManagerTests
    {
        [Fact]
        public void CheckMatchManager_ParsedMessagesAsInput_ExpectedCorrectConstructionOfModel()
        {
            var parser = new Vgbot.Core.Parser.Parser();
            var messages = new List<AbstractMessage>();

            FileStream fileStream = new FileStream("../../../Testfiles/20181025.log", FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var dataPacket = new DataPacket(Encoding.Default.GetBytes(line), new IPEndPoint(IPAddress.Any, 0));
                    var message = parser.TryParse(dataPacket);
                    if (message != null)
                    {
                        messages.Add(message);
                    }
                }
            }
            Assert.Equal(15785, messages.Count);
        }
    }
}
