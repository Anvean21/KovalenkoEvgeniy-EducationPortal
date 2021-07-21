using EducationPortal.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Command
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>();
        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();

        private readonly Dictionary<int, IAuthCommand> authCommands = new Dictionary<int, IAuthCommand>();
        public IEnumerable<IAuthCommand> AuthCommands => this.authCommands.Values.AsEnumerable();

        public CommandProcessor(IEnumerable<ICommand> commands, IEnumerable<IAuthCommand> auCommands)
        {
            foreach (var command in commands)
            {
                this.commands.Add(command.CommandNumber, command);
            }
            foreach (var command in auCommands)
            {
                this.authCommands.Add(command.CommandNumber, command);
            }
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command))
            {
                return;
            }
            command.Execute();
        }

        public void AuthProcess(int number)
        {
            if (!this.authCommands.TryGetValue(number, out var command))
            {
                return;
            }
            command.Execute();
        }
    }
}
