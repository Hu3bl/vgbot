using System.Collections.Generic;
using System.Linq;
using Vgbot.Core.Messages;
using Vgbot.Core.Parser.MessageRegex;

namespace Vgbot.Core.Parser
{
    public class Parser
    {
        private List<IRegex> regexList;
        public Parser()
        {
            Init();
        }

        private void Init()
        {
            regexList = new List<IRegex>();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            foreach (System.Reflection.TypeInfo typeInfo in assembly.DefinedTypes)
            {
                if (typeInfo.ImplementedInterfaces.Contains(typeof(IRegex)))
                {
                    regexList.Add(assembly.CreateInstance(typeInfo.FullName) as IRegex);
                }  
            }
        }

        public bool TryParse(string data, out IMessage message)
        {
            message = null;
            foreach(var regex in regexList)
            {
                if(regex.TryParse(data, out message))
                {
                    return true;
                }
            }
            return false;
        }
    }
}