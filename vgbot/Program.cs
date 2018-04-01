using System;
using System.Collections.Concurrent;
using System.IO;
using vgbot.core.listener;

namespace vgbot
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new BlockingCollection<byte[]>(new ConcurrentQueue<byte[]>());
            var listener = new Listener(buffer);
            listener.BeginListening();

            byte[] receivedData = null;

            while(true)
            {
                receivedData = buffer.Take();
                String data = System.Text.Encoding.Default.GetString(receivedData);
                
                Console.WriteLine(data);
                using (StreamWriter writer = new StreamWriter("./logOfServer.log", true))
                {
                    writer.WriteLine(data);
                }    
            }
        }
    }
}
