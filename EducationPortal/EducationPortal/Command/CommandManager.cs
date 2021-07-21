using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Command
{
    public class CommandManager
    {
        private readonly ICommandProcessor commandProcessor;
        private string info;
        public CommandManager(ICommandProcessor commandProcessor)
        {
            this.commandProcessor = commandProcessor;
        }

        public void Start()
        {
            this.SetupInfo();

            Console.WriteLine(this.info);

            var inputCommand = Console.ReadLine();
            var command = 0;

            if (string.IsNullOrWhiteSpace(inputCommand) || !int.TryParse(inputCommand, out command))
            {
                Start();
            }

            this.commandProcessor.Process(command);
        }
        public void AuthStart()
        {
            this.AuthSetupInfo();

            Console.WriteLine(this.info);

            var inputCommand = Console.ReadLine();
            var command = 0;

            if (string.IsNullOrWhiteSpace(inputCommand) || !int.TryParse(inputCommand, out command))
            {
                AuthStart();
            }

            this.commandProcessor.AuthProcess(command);
        }
        private void SetupInfo()
        {
            var stringBuilder = new StringBuilder();
            var commands = this.commandProcessor.Commands;

            stringBuilder.AppendLine("Select operation");

            foreach (var command in commands)
            {
                stringBuilder.AppendLine($"{command.CommandNumber}. {command.CommandName}");
            }
            this.info = stringBuilder.ToString();
        }
        private void AuthSetupInfo()
        {
            var stringBuilder = new StringBuilder();
            var commands = this.commandProcessor.AuthCommands;

            stringBuilder.AppendLine("Select operation");

            foreach (var command in commands)
            {
                stringBuilder.AppendLine($"{command.CommandNumber}. {command.CommandName}");
            }
            this.info = stringBuilder.ToString();
        }
    }
}
