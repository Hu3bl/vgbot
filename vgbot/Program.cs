using System;
using System.Collections.Concurrent;
using System.IO;
using vgbot.Core.Listener;
using Vgbot.Core.Listener;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser;
using Vgbot.Core.Parser.MessageRegex;

namespace Vgbot
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new BlockingCollection<DataPacket>(new ConcurrentQueue<DataPacket>());
            var listener = new Listener(buffer, 3000);
            listener.BeginListening();

            Parser parser = new Parser();

            while(true)
            {
                var dataPacket = buffer.Take();
                //var message = parser.TryParse(dataPacket);

                Console.WriteLine(System.Text.Encoding.Default.GetString(dataPacket.Data));
                using (StreamWriter writer = new StreamWriter("./20181124.log", true))
                {
                    writer.WriteLine(System.Text.Encoding.Default.GetString(dataPacket.Data));
                }
            }
        }
    }
}
