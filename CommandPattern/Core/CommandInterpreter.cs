using System;
using System.Collections.Generic;
using CommandPattern.Core.Contracts;
using System.Text;
using System.Linq;
using CommandPattern.Commands;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }

        public string Read(string args)
        {
            
            string[] parts = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandType = parts[0];
            string[] commandArgs = parts.Skip(1).ToArray();
            
            ICommand command = commandFactory.CreateCommand(commandType);
            
            if(command != null)
            {
                return command.Execute(commandArgs);
            }

            return null;

        }
    }
}
