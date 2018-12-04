using System.Collections.Generic;
using System.Linq;
using vgbot.Core.Listener;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;

namespace Vgbot.Core.Parser
{
    public class Parser
    {
        private List<IRegex> _regexList;
        public Parser()
        {
            Init();
        }

        private void Init()
        {
            _regexList = new List<IRegex>();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(GetType());
            foreach (System.Reflection.TypeInfo typeInfo in assembly.DefinedTypes)
            {
                if (typeInfo.ImplementedInterfaces.Contains(typeof(IRegex)))
                {
                    _regexList.Add(assembly.CreateInstance(typeInfo.FullName) as IRegex);
                }  
            }
        }

        public AbstractMessage TryParse(DataPacket dataPacket)
        {
            string data = System.Text.Encoding.Default.GetString(dataPacket.Data);
            foreach (var regex in _regexList)
            {
                AbstractMessage abstractMessage = regex.Parse(data);
                if (abstractMessage != null)
                {
                    abstractMessage.IpEndPoint = dataPacket.From;
                    return abstractMessage;
                }
            }
            return null;
        }
    }
}