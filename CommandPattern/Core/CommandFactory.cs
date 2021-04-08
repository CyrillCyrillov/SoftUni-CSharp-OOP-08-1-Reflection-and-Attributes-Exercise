using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";

        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{commandType}{CommandSuffix}");

            
            if (type == null)
            {
                //Environment.Exit(0);
                return null;
                
                //throw new ArgumentException($"{commandType} is invalid command type.");
            }
            
            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
