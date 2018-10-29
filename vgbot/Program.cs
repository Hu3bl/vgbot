﻿using System;
using System.Collections.Concurrent;
using System.IO;
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
            var parser = new Parser();

            FileStream fileStream = new FileStream("./logOfServer2.log", FileMode.Open);
            //Console.WriteLine(fileStream.);
            using (var reader = new StreamReader(fileStream))
            {
                String line;
                while((line = reader.ReadLine()) != null)  
                {  
                    if(line.Length < 2)
                    {
                        continue;
                    }
                    if(parser.TryParse(line))
                    {
                        //Console.WriteLine(line);
                        //Console.WriteLine(message.ToString());
                    }
                    else
                    {
                        Console.WriteLine (line); 
                    }
                     
                } 
                
                //string line = reader.ReadLine();
                //Console.WriteLine(line);
            }
            
            
            
            var buffer = new BlockingCollection<byte[]>(new ConcurrentQueue<byte[]>());
            var listener = new Listener(buffer);
            listener.BeginListening();

            byte[] receivedData = null;
            //Parser parser = new Parser();

            while(true)
            {
                receivedData = buffer.Take();
                String data = System.Text.Encoding.Default.GetString(receivedData);
                                
                //parser.Parse()

                Console.WriteLine(data);
                using (StreamWriter writer = new StreamWriter("./logOfServer3.log", true))
                {
                    writer.WriteLine(data);
                }    
            }
        }
    }
}
