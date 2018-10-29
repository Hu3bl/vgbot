using System.Collections.Generic;
using System.Linq;
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
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            foreach (System.Reflection.TypeInfo typeInfo in assembly.DefinedTypes)
            {
                if (typeInfo.ImplementedInterfaces.Contains(typeof(IRegex)))
                {
                    _regexList.Add(assembly.CreateInstance(typeInfo.FullName) as IRegex);
                }  
            }
        }

        public bool TryParse(string data)
        {
            foreach(var regex in _regexList)
            {
                IMessage message = regex.Parse(data);
                if (message != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}