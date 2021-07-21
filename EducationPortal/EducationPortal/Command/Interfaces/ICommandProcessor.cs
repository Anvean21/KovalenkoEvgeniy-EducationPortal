using EducationPortal.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Command
{
    public interface ICommandProcessor
    {
        void Process(int command);
        void AuthProcess(int command);
        IEnumerable<ICommand> Commands { get; }
        IEnumerable<IAuthCommand> AuthCommands { get; }
    }
}
